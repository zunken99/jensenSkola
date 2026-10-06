using CommunityToolkit.Mvvm.ComponentModel;


namespace Client.Viewmodels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial string PageTitle {get; set;} = "";
}
