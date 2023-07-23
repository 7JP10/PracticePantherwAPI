using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EntryNumber), "entryNumber")]
public partial class TimeDetail : ContentPage
{
	public TimeDetail()
	{
		InitializeComponent();
	}

    public int EntryNumber { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

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
        (BindingContext as TimeViewModel).UpdateTime2();
        Shell.Current.GoToAsync("//Client");
    }

    public void CancelTimeAddClick(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).ClearProperties();
        Shell.Current.GoToAsync("//Client");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (EntryNumber > 0)
        {
            BindingContext = new TimeViewModel(EntryNumber);
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
