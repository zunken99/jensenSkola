using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class CustomerViewModel : ViewModelBase
{
    public CustomerViewModel()
    {
        PageTitle = "Customers";
    }
}
