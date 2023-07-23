using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ManageEmployee : ContentPage
{
    public ManageEmployee()
    {
        InitializeComponent();
        BindingContext = new EmployeeVVModel();
    }

    //******************************************************************************
    //******************************************************************************

    private void EmployeeAddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddEmployee");
    }

    private void ViewEmployeeClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVVModel).RefreshEmployeeList();
    }

    private void EditEmployeeClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVVModel).RefreshEmployeeList();
    }

    private void DeleteEmployeeClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVVModel).RefreshEmployeeList();
    }

    private void SearchEmployeeClick(object sender, EventArgs e)
    {
        (BindingContext as EmployeeVVModel).SearchEmployee();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    //******************************************************************************
    //******************************************************************************

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeVVModel).RefreshEmployeeList();
    }
}