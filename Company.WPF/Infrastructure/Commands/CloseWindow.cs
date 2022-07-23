using Company.WPF.Infrastructure.Commands.Base;
using System.Windows;

namespace Company.WPF.Infrastructure.Commands
{
    /// <summary>
    /// Закрытие окна
    /// </summary>
    public class CloseWindow : Command
    {
        protected override void Execute(object? parameter)
        {
            (parameter as Window ?? App.FocusedWindow ?? App.ActiveWindow)?.Close();
        }

        protected override bool CanExecute(object? parameter)
        {
            return (parameter as Window ?? App.FocusedWindow ?? App.ActiveWindow) != null;
        }
    }
}
