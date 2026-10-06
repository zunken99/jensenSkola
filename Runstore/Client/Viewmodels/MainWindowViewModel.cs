using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Client.Views;

namespace Client.Viewmodels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly HomeViewModel _homeView = new();
    private readonly ProductViewModel _productsView = new();
    private readonly CustomerViewModel _customerView = new();
    private readonly OrderViewModel _ordersView = new();
    


    [ObservableProperty]
    public partial ViewModelBase CurrentView{get; set;}
    public MainWindowViewModel()
    {
        CurrentView = _homeView;
    }

    [RelayCommand]
    private void GoToHome() => CurrentView = _homeView;
    
    [RelayCommand]
    private void GoToProducts() => CurrentView = _productsView;
    
    [RelayCommand]
    private void GoToCustomer() => CurrentView = _customerView;

    [RelayCommand]
    private void GoToOrders() => CurrentView = _ordersView;

    
}
