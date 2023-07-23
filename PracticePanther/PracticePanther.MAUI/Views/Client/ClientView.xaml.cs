namespace PracticePanther.MAUI.Views;
using PracticePanther.MAUI.ViewModels;

public partial class ClientView : ContentPage
{
    public ClientView()
    {
        InitializeComponent();
        BindingContext = new ClientVVModel();
    }

    private void SearchClientClick(object sender, EventArgs e)
    {
        (BindingContext as ClientVVModel).SearchClient();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientAdd");
        (BindingContext as ClientVVModel).RefreshClientList();
    }

    private void BillClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientVVModel).RefreshClientList();
    }

    private void ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientVVModel).RefreshClientList();
    }


    private void ViewClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientVVModel).RefreshClientList();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientVVModel).RefreshClientList();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientVVModel).RefreshClientList();
    }

    //******************************************************************************
    //******************************************************************************

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientVVModel).RefreshClientList();
    }
}