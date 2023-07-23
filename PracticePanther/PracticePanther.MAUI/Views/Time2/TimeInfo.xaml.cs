using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EntryNumber), "entryNumber")]
public partial class TimeInfo : ContentPage
{
	public TimeInfo()
	{
		InitializeComponent();
	}

    public int EntryNumber { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    public void Cancel2Clicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//ManageTime");

        //if (EntryNumber > 0)
        //{
            //int cId = (BindingContext as TimeViewModel).Model.ClientId;
            //Shell.Current.GoToAsync($"//TimeInfo?clientId={cId}");
        //}
        //else
        //{
            Shell.Current.GoToAsync("//Client");
        //}
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
