namespace Company.WPF.Infrastructure.Services.Interfaces;

public interface IUserDialogService
{
    void ShowInformation(string Information, string Caption);
    void ShowWarning(string Message, string Caption);
    void ShowError(string Message, string Caption);
    bool Confirm(string Message, string Caption, bool Exclamation = false);
}