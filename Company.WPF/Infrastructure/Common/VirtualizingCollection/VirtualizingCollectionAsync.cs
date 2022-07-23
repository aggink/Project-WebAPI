using System.Collections.Specialized;
using System.ComponentModel;

namespace Company.WPF.Infrastructure.Common.VirtualizingCollection;

/// <summary>
/// Производная коллекция VirtualizatingCollection, выполняющая асинхронную загрузку.
/// </summary>
public class VirtualizingCollectionAsync<T> : VirtualizingCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
{
    public SynchronizationContext? SynchronizationContext { get; private set; }

    public VirtualizingCollectionAsync(
        IVirtualizingCollection<T> virtualizingCollection)
        : base(virtualizingCollection)
    {
        SynchronizationContext = SynchronizationContext.Current;
    }

    #region INotifyCollectionChanged

    /// <summary>
    /// Происходит при изменении коллекции
    /// </summary>
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    /// <summary>
    /// Вызывает событие <see cref="E:CollectionChanged"/>.
    /// </summary>
    private void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);
    
    /// <summary>
    /// Запускает событие сброса коллекции.
    /// </summary>
    private void FireCollectionReset()
    {
        NotifyCollectionChangedEventArgs e = new(NotifyCollectionChangedAction.Reset);
        OnCollectionChanged(e);
    }

    #endregion

    #region INotifyPropertyChanged

    /// <summary>
    /// Происходит при изменении значения свойства.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Вызывает событие <see cref="E:PropertyChanged"/>.
    /// </summary>
    private void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);

    /// <summary>
    /// Запускает событие изменения свойства.
    /// </summary>
    private void FirePropertyChanged(string propertyName)
    {
        PropertyChangedEventArgs e = new(propertyName);
        OnPropertyChanged(e);
    }

    #endregion

    #region IsLoading

    private bool _isLoading;

    /// <summary>
    /// Получает или задает значение, указывающее, загружается ли коллекция.
    /// </summary>
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            if (value != _isLoading)
                _isLoading = value;
            FirePropertyChanged(nameof(IsLoading));
        }
    }

    #endregion

    #region Load overrides

    /// <summary>
    /// Асинхронно загружает страницу.
    /// </summary>
    protected override void LoadPage(int index)
    {
        IsLoading = true;
        ThreadPool.QueueUserWorkItem(LoadPageWork, index);
    }

    /// <summary>
    /// Выполняется в фоновом потоке.
    /// </summary>
    private async void LoadPageWork(object? args)
    {
        int pageIndex = (int)args!;
        (IList<T>? page, int count) = await FetchPageAsync(pageIndex);
        SynchronizationContext?.Send(LoadPageCompleted, new object?[] { pageIndex, page, count });
    }

    /// <summary>
    /// Выполняется в UI-потоке после LoadPageWork.
    /// </summary>
    private void LoadPageCompleted(object? args)
    {
        int pageIndex = (int)((object[])args!)[0];
        IList<T> page = (IList<T>)((object[])args)[1];
        int count = (int)((object[])args)[2];

        PopulatePage(pageIndex, page);
        Count = count;

        IsLoading = false;
        FireCollectionReset();
    }

    #endregion


    #region Refresh override

    public override void RefreshPages()
    {
        IsLoading = true;
        ThreadPool.QueueUserWorkItem(RefreshPagesWork, GetKeys());
    }

    private async void RefreshPagesWork(object? arg)
    {
        List<int> pageIndexs = (List<int>)arg!;

        int count = 0;
        List<IList<T>?> pages = new();
        foreach (int pageIndex in pageIndexs)
        {
            (var page, count) = await FetchPageAsync(pageIndex);
            pages.Add(page);
        }

        SynchronizationContext?.Send(RefreshPagesCompleted, new object[] { pageIndexs, pages, count });
    }

    private void RefreshPagesCompleted(object? args)
    {
        List<int> pageIndexs = (List<int>)((object[])args!)[0];
        List<IList<T>> pages = (List<IList<T>>)((object[])args)[1];
        int count = (int)((object[])args)[2];

        for (int i = 0; i < pageIndexs.Count; i++)
        {
            if (!pages[i].Any())
            {
                PopulatePage(pageIndexs[i], pages[i]);
                UpdateTimePage(pageIndexs[i]);
            }
            else
            {
                RemovePage(pageIndexs[i]);
            }
        }

        Count = count;

        IsLoading = false;
        FireCollectionReset();
    }

    #endregion
}