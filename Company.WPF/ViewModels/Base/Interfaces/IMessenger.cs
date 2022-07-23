namespace Company.WPF.ViewModels.Base.Interfaces;

/// <summary>
/// Интерфейс предоставляющий методы типизированного месенджера
/// </summary>
public interface IMessenger
{
    /// <summary>
    /// Регистрирация метода-прослушки на определённый тип сообщения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    void Register<T>(Action<T> action);

    /// <summary>
    /// Отписка от регистрации метода-прослушки на определённый тип сообщения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    void Unregister<T>(Action<T> action);

    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    void Send<T>(T message);
}
