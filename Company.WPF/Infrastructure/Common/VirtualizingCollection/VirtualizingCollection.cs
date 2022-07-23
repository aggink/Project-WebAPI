using System.Collections;
using System.Collections.Generic;

namespace Company.WPF.Infrastructure.Common.VirtualizingCollection;

/// <summary>
/// Реализация специализированного списка, обеспечивающая виртуализацию данных. Коллекция разделена на страницы, 
/// и страницы при необходимости динамически извлекаются из IItemsProvider. 
/// Устаревшие страницы удаляются через настраиваемый период времени. 
/// Предназначен для использования с большими коллекциями в сети или на дисковом ресурсе, 
/// которые не могут быть созданы локально из-за потребления памяти или задержки выборки.
/// </summary>
/// <remarks>
/// Для увелечения функционала позже можно реализовать интерфейсы IList<T>, IList
/// </remarks>
public abstract class VirtualizingCollection<T> : IEnumerable<T>
{
    private readonly IVirtualizingCollection<T> _VirtualizingCollection;
    
    public VirtualizingCollection(
        IVirtualizingCollection<T> virtualizingCollection)
    {
        _VirtualizingCollection = virtualizingCollection;
    }

    /// <summary>
    /// Получить размер страницы
    /// </summary>
    public int PageSize { get; set; } = 100;

    /// <summary>
    /// Получить время ожидания страницы
    /// </summary>
    public long PageTimeout { get; set; } = 100000;

    #region Count

    private int _count = -1;

    /// <summary>
    /// Получить количество элементов в коллекции
    /// </summary>
    public virtual int Count
    {
        get
        {
            if (_count == -1) FetchPageAsync(1);
            return _count;
        }
        protected set
        {
            _count = value;
        }
    }

    #endregion

    /// <summary>
    /// Получает элемент по указанному индексу. Это свойство при необходимости извлечет соответствующую страницу из IItemsProvider.
    /// </summary>
    public T? this[int index]
    {
        get
        {
            // определить, какая страница и смещение внутри страницы
            int pageIndex = index / PageSize;
            int pageOffset = index % PageSize;

            // запросить основную страницу
            RequestPage(pageIndex);

            // при доступе к верхним 50% запросите следующую страницу
            if (pageOffset > PageSize / 2 && pageIndex < Count / PageSize)
                RequestPage(pageIndex + 1);

            // при доступе к более низким 50% запросите предыдущую страницу
            if (pageOffset < PageSize / 2 && pageIndex > 0)
                RequestPage(pageIndex - 1);

            // удалить устаревшие страницы
            CleanUpPages();

            // защитная проверка в случае асинхронной загрузки
            if (_pages[pageIndex] == null) return default;

            // return requested item
            return _pages[pageIndex]![pageOffset];
        }
        set { throw new NotSupportedException(); }
    }

    /// <summary>
    /// Возвращает перечислитель, который выполняет итерацию по коллекции.
    /// </summary>
    /// <returns></returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return this[i];
        }
    }

    /// <summary>
    /// Возвращает перечислитель, который перебирает коллекцию.
    /// </summary>
    /// <returns></returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #region Работа со страницами

    private readonly Dictionary<int, IList<T>?> _pages = new();
    private readonly Dictionary<int, DateTime> _pageTouchTimes = new();

    /// <summary>
    /// Получение списка ключей
    /// </summary>
    protected List<int> GetKeys() => _pages.Keys.ToList();

    /// <summary>
    /// Удаляет все устаревшие страницы, к которым не обращались в течение периода, установленного параметром PageTimeout.
    /// </summary>
    public void CleanUpPages()
    {
        List<int> keys = new(_pageTouchTimes.Keys);
        foreach (int key in keys)
        {
            // страница 0 является особым случаем, так как WPF ItemsControl часто обращается к первому элементу
            if (key != 0 && (DateTime.Now - _pageTouchTimes[key]).TotalMilliseconds > PageTimeout)
            {
                _pages.Remove(key);
                _pageTouchTimes.Remove(key);
            }
        }
    }

    /// <summary>
    /// Удаляет страницу в словаре.
    /// </summary>
    /// <param name="pageIndex"></param>
    protected void RemovePage(int pageIndex)
    {
        if (_pages.ContainsKey(pageIndex) && pageIndex != 0)
        {
            _pages.Remove(pageIndex);
            _pageTouchTimes.Remove(pageIndex);
        }
    }

    /// <summary>
    /// Обновляет время у страницы
    /// </summary>
    /// <param name="pageIndex"></param>
    protected void UpdateTimePage(int pageIndex)
    {
        if (_pages.ContainsKey(pageIndex))
        {
            _pageTouchTimes[pageIndex] = DateTime.Now;
        }
    }

    /// <summary>
    /// Заполняет страницу в словаре.
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="page"></param>
    protected void PopulatePage(int pageIndex, IList<T>? page)
    {
        if (_pages.ContainsKey(pageIndex))
            _pages[pageIndex] = page;
    }

    /// <summary>
    /// Делает запрос на указанную страницу, создавая необходимые слоты в словаре и обновляя время запроса страницы.
    /// </summary>
    /// <param name="pageIndex"></param>
    private void RequestPage(int pageIndex)
    {
        if (!_pages.ContainsKey(pageIndex))
        {
            _pages.Add(pageIndex, null);
            _pageTouchTimes.Add(pageIndex, DateTime.Now);
            LoadPage(pageIndex);
        }
        else
        {
            _pageTouchTimes[pageIndex] = DateTime.Now;
        }
    }

    #endregion

    #region Обновление страниц

    /// <summary>
    /// Обновление загруженных страниц
    /// </summary>
    public virtual async void RefreshPages()
    {
        var keys = _pages.Keys.ToList();
        int count = 0;
        for (int i = 0; i < keys.Count; i++)
        {
            (var page, count) = await FetchPageAsync(keys[i]);
            if (page == null || page.Any() && keys[i] != 0)
            {
                RemovePage(keys[i]);
            }
            else
            {
                _pages[keys[i]] = page;
                _pageTouchTimes[keys[i]] = DateTime.Now;
            }
        }

        Count = count;
    }

    #endregion

    #region Загрузка страниц

    /// <summary>
    /// Загрузка страницы элементов
    /// </summary>
    /// <param name="pageIndex"></param>
    protected virtual async void LoadPage(int pageIndex)
    {
        (var page, var count) = await FetchPageAsync(pageIndex);
        Count = count;
        PopulatePage(pageIndex, page);
    }

    #endregion

    #region Запросы к Базе данных

    /// <summary>
    /// Извлекает запрошенную страницу.
    /// </summary>
    /// <param name="pageIndex">Номер страницы</param>
    /// <returns></returns>
    protected Task<(IList<T>? page, int count)> FetchPageAsync(int pageIndex) =>_VirtualizingCollection.FetchPage(PageSize, pageIndex);

    #endregion
}