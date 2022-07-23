using Company.WPF.ViewModels.Base.Interfaces;

namespace Company.WPF.ViewModels.Base;

/// <summary>
/// Типизированный Мессенджер
/// </summary>
public class Messenger : IMessenger
{
    protected static readonly Dictionary<Type, List<Delegate>> actions = new();

    /// <summary>
    /// Регистрирация метода-прослушки на определённый тип сообщения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Register<T>(Action<T> action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        lock (action)
        {
            Type type = typeof(T);
            if (actions.TryGetValue(type, out List<Delegate>? list))
            {
                if (!list.Contains(action))
                    list.Add(action);
            }
            else
            {
                actions.Add(type, new List<Delegate> { action });
            }
        }
    }

    /// <summary>
    /// Отписка от регистрации метода-прослушки на определённый тип сообщения
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Unregister<T>(Action<T> action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        lock(actions)
        {
            Type type = typeof(T);
            if (actions.TryGetValue(type, out List<Delegate>? list))
                list.RemoveAll(a => (Action<T>)a == action);
        }
    }

    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    public void Send<T>(T message)
    {
        lock (actions)
        {
            Type type = typeof(T);
            if (actions.TryGetValue(type, out List<Delegate>? list))
                list.ForEach(dlgt => ((Action<T>)dlgt)(message));
        }
    }
}