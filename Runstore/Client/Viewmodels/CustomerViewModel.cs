using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class CustomerViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _customerName = string.Empty;

}
