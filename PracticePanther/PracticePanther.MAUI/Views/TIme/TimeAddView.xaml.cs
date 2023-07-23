using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class TimeAddView : ContentPage
{
	public TimeAddView()
	{
		InitializeComponent();
	}

    //******************************************************************************
    //******************************************************************************

    private void SearchProjectClick(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).SearchProject();
    }

    private void SearchEmployeeClick(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).SearchEmployee();
    }


    public void OkClick(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).AddTime();
        Shell.Current.GoToAsync("//ManageTime");
    }

    public void CancelTimeAddClick(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).ClearProperties();
        Shell.Current.GoToAsync("//ManageTime");
    }

    //******************************************************************************
    //******************************************************************************

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
        (BindingContext as TimeViewModel).RefreshLists();
    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TimeViewModel).ClearProperties();
        BindingContext = null;
    }
}
