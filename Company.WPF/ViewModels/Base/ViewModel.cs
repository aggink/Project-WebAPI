﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xaml;

namespace Company.WPF.ViewModels.Base;

public abstract class ViewModel : MarkupExtension, INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        var handlers = PropertyChanged;
        if (handlers == null) return;

        var invocation_list = handlers.GetInvocationList();
        var arg = new PropertyChangedEventArgs(propertyName);

        foreach(var action in invocation_list)
        {
            if(action.Target is DispatcherObject disp_object)
            {
                disp_object.Dispatcher.Invoke(action, this, arg);
            }
            else
            {
                action.DynamicInvoke(this, arg);
            }
        }
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value)) return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var value_target_service = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        var root_object_service = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

        OnInitialized(
            value_target_service?.TargetObject,
            value_target_service?.TargetProperty,
            root_object_service?.RootObject);

        return this;
    }

    private WeakReference? _TargetRef;
    private WeakReference? _RootRef;

    public object? TargetObject => _TargetRef?.Target;
    public object? RootObject => _RootRef?.Target;

    protected virtual void OnInitialized(object? Target, object? Property, object? Root)
    {
        _TargetRef = new WeakReference(Target);
        _RootRef = new WeakReference(Root);
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private bool _Disposed;
    protected virtual void Dispose(bool Disposing)
    {
        if (!Disposing || _Disposed) return;
        _Disposed = true;
    }
}
