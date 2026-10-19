using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class OrderViewModel : ViewModelBase
{
     public OrderViewModel()
    {
        PageTitle = "Orders";
    }
}
