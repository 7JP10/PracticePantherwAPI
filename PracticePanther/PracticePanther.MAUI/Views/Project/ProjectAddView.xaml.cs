namespace PracticePanther.MAUI.Views;

using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectAddView : ContentPage
{
    public ProjectAddView()
    {
        InitializeComponent();

    }

    public int ClientId { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewModel).Add();
        Shell.Current.GoToAsync($"//ManageProject?clientId={ClientId}");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ManageProject?clientId={ClientId}");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (ClientId > 0)
        {
            BindingContext = new ProjectViewModel(ClientId);
        }
        else
        {
            Shell.Current.GoToAsync("//Client");
        }

    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
    }
}