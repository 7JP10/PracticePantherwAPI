using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class ViewEmployeeView : ContentPage
{
    public ViewEmployeeView()
    {
        InitializeComponent();
    }

    public int EmployeeId { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ManageEmployee");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (EmployeeId > 0)
        {
            BindingContext = new EmployeeViewModel(EmployeeId);
        }
        else
        {
            Shell.Current.GoToAsync("//ManageEmployee");
        }

    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
    }
}