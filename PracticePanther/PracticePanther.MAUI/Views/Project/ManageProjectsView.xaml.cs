using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ManageProjectsView : ContentPage
{
    public ManageProjectsView()
    {
        InitializeComponent();
    }

    public int ClientId { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void ProjectAddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//AddProject?clientId={ClientId}");
        (BindingContext as ProjectVVModel).RefreshProjectList();
        //Shell.Current.GoToAsync("//AddProject");
    }

    private void ViewProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectVVModel).RefreshProjectList();
    }

    private void EditProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectVVModel).RefreshProjectList();
    }


    private void DeleteProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectVVModel).RefreshProjectList();
    }

    private void SearchProjectClick(object sender, EventArgs e)
    {
        (BindingContext as ProjectVVModel).SearchProject();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (ClientId > 0)
        {
            BindingContext = new ProjectVVModel(ClientId);
            (BindingContext as ProjectVVModel).RefreshProjectList();
        }
        else
        {
            Shell.Current.GoToAsync($"//Client");
        }
    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {

        BindingContext = null;

    }
}