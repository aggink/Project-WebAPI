using Company.WPF.Infrastructure.Commands.Base;
using Company.WPF.Infrastructure.Common.VirtualizingCollection;
using Company.WPF.Infrastructure.Services.Interfaces;
using Company.WPF.Models.Product;
using Company.WPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace Company.WPF.ViewModels;

public class ParserScanResultsViewModel<T> : ViewModel
{
    private static Window ActiveWindow => Application.Current.Windows.OfType<MainWindow>().First();

    private readonly IHttpListnerService _HttpListnerService;
    private readonly IUserDialogService _UserDialogService;

    public ParserScanResultsViewModel(
        IHttpListnerService HttpListnerService,
        IUserDialogService UserDialogService)
    {
        _HttpListnerService = HttpListnerService;
        _UserDialogService = UserDialogService;
    }

    #region Результаты сканирования

    private VirtualizingCollectionAsync<T>? _Products;

    public VirtualizingCollectionAsync<T>? Products { get => _Products; set => Set(ref _Products, value); }

    #endregion

    #region Выбранный результат

    private T? _SelectedProduct;

    public T? SelectedProduct { get => _SelectedProduct; set => Set(ref _SelectedProduct, value); }

    #endregion

    #region Команда редактирования записи

    private ICommand? _UpdateProductCommandExecute;

    public ICommand UpdateProductCommandExecute =>
        _UpdateProductCommandExecute ??= new LambdaCommand(
            OnUpdateProductCommandExecute,
            CanUpdateProductCommandExecute);

    private bool CanUpdateProductCommandExecute(object? p)
    {
        if(SelectedProduct == null) return false;
        return true;
    }

    private async void OnUpdateProductCommandExecute(object? p)
    {
        string message = "Ошибка при редактировании данных";
        string caption = "Ошибка";
        bool flag = false;

        if (SelectedProduct is BulatProduct BProduct)
        {
            var result = await _HttpListnerService.BulatProductPUTAsync(BProduct);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else if (SelectedProduct is RamisProduct RProduct)
        {
            var result = await _HttpListnerService.RamisProductPUTAsync(RProduct);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else if (SelectedProduct is ZipZipProduct ZProduct)
        {
            var result = await _HttpListnerService.ZipZipProductPUTAsync(ZProduct);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else if (SelectedProduct is ChipCartProduct CProduct)
        {
            var result = await _HttpListnerService.ChipCartProductPUTAsync(CProduct);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else
        {
            throw new Exception();
        }

        if (flag) Products!.RefreshPages();
    }

    #endregion

    #region Команда удаления записи

    private ICommand? _DeleteProductCommandExecute;

    public ICommand DeleteProductCommandExecute =>
        _DeleteProductCommandExecute ??= new LambdaCommand(
            OnDeleteProductCommandExecute,
            CanDeleteProductCommandExecute);

    private bool CanDeleteProductCommandExecute(object? p)
    {
        if (SelectedProduct == null) return false;
        return true;
    }

    private async void OnDeleteProductCommandExecute(object? p)
    {
        string message = "Ошибка при удалении";
        string caption = "Ошибка";
        bool flag = false;

        if(SelectedProduct is BulatProduct BProduct)
        {
            var result = await _HttpListnerService.BulatProductDELETEAsync(BProduct.Id);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else if(SelectedProduct is RamisProduct RProduct)
        {
            var result = await _HttpListnerService.RamisProductDELETEAsync(RProduct.Id);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else if(SelectedProduct is ZipZipProduct ZProduct)
        {
            var result = await _HttpListnerService.ZipZipProductDELETEAsync(ZProduct.Id);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else if(SelectedProduct is ChipCartProduct CProduct)
        {
            var result = await _HttpListnerService.ChipCartProductDELETEAsync(CProduct.Id);
            if (!result) _UserDialogService.ShowError(message, caption);
            else flag = true;
        }
        else
        {
            throw new Exception();
        }

        if (flag) Products!.RefreshPages();
    }

    #endregion
}