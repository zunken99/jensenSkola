using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.Viewmodels;

public partial class ProductViewModel : ViewModelBase
{
    public ProductViewModel()
    {
        PageTitle = "Products";
    }
}
