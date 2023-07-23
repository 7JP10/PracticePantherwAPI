using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ViewProjectView : ContentPage
{
    public ViewProjectView()
    {
        InitializeComponent();
    }

    public int ProjectId { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void CancelClicked(object sender, EventArgs e)
    {
        if (ProjectId > 0)
        {
            int cId = (BindingContext as ProjectViewModel).Model.ClientId;
            Shell.Current.GoToAsync($"//ManageProject?clientId={cId}");
        }
        else
        {
            Shell.Current.GoToAsync("//Client");
        }

    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (ProjectId > 0)
        {
            BindingContext = new ProjectViewModel(ProjectId, true);
            (BindingContext as ProjectViewModel).RefreshBillList();
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