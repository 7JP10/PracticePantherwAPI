using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ViewClientView : ContentPage
{
    public ViewClientView()
    {
        InitializeComponent();
    }

    public int ClientId { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        //if (ClientId > 0)
        //{
            BindingContext = new ClientViewModel(ClientId);
            (BindingContext as ClientViewModel).RefreshProjectList();
        //}
        //else
        //{
            //Shell.Current.GoToAsync("//Client");
        //}
    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
    }
}