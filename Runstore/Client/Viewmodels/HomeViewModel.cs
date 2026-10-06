using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class HomeViewModel : ViewModelBase
{
    public HomeViewModel()
    {
        PageTitle = "Runstore Admin";
    }
}
