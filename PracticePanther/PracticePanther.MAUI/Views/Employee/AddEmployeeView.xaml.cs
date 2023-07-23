using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class AddEmployeeView : ContentPage
{
    public AddEmployeeView()
    {
        InitializeComponent();
    }
    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void AddEmployeeClicked(object sender, EventArgs e)
    {

        (BindingContext as EmployeeViewModel).Add();
        Shell.Current.GoToAsync("//ManageEmployee");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ManageEmployee");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel();
    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {

        BindingContext = null;

    }
}