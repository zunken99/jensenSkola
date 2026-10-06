using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class ProductViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _pageTitle = "Products";
}
