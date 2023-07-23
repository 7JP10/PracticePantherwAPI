using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ManageTimeView : ContentPage
{
	public ManageTimeView()
	{
		InitializeComponent();
	}

    public int ClientId { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    private void TimeAddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddTime");
    }

    private void ViewTimeClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeVVModel).RefreshTimeList();
    }

    private void EditTimeClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeVVModel).RefreshTimeList();
    }

    private void DeleteTimeClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeVVModel).RefreshTimeList();
    }

    private void SearchTimeClick(object sender, EventArgs e)
    {
        //(BindingContext as TimeVVModel).SearchTime();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    //************************************************************************
    //************************************************************************
    //************************************************************************


    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        if (ClientId > 0)
        {
            BindingContext = new BillVVModel(ClientId);
            (BindingContext as BillVVModel).RefreshTimeList();
        }
        else
        {
            Shell.Current.GoToAsync($"//Client");
        }
    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {

        BindingContext = null;

    }
}
