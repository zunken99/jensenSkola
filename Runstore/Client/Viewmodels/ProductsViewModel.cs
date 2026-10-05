using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class ProductsViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _pageTitle = "Products";
}
