using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class AddClientView : ContentPage
{
    public AddClientView()
    {
        InitializeComponent();
    }

    private void OkClicked(object sender, EventArgs e)
    {

        (BindingContext as ClientViewModel).Add();
        Shell.Current.GoToAsync("//Client");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel();
    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {

        BindingContext = null;

    }
}