using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Client.Viewmodels;

namespace Client;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if(data is null) return null;

        //find right view for the given viewmodel
        var viewName = data.GetType().FullName!
            .Replace("Viewmodels.", "Views.", StringComparison.Ordinal)
            .Replace("ViewModel", "View", StringComparison.Ordinal);
        var viewType = Type.GetType(viewName);

        if(viewType is null) return null;

        var control = (Control)Activator.CreateInstance(viewType)!;
        control.DataContext = data;
        return control;
    }

    public bool Match(object? data) => data is ViewModelBase;
    
}
