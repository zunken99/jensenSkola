using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _pageTitle = "Runstore Admin";
}
