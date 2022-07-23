using Company.WPF.Infrastructure.Services.Interfaces;
using System.Windows;

namespace Company.WPF.Infrastructure.Services;

public class UserDialogService : IUserDialogService
{
    public void ShowInformation(string Information, string Caption) => MessageBox.Show(Information, Caption, MessageBoxButton.OK, MessageBoxImage.Information);

    public void ShowWarning(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Warning);

    public void ShowError(string Message, string Caption) => MessageBox.Show(Message, Caption, MessageBoxButton.OK, MessageBoxImage.Error);

    public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
        MessageBox.Show(
            Message,
            Caption,
            MessageBoxButton.YesNo,
            Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
        == MessageBoxResult.Yes;
}