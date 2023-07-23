using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ManageTime : ContentPage
{
	public ManageTime()
	{
		InitializeComponent();
        BindingContext = new TimeVVModel();
    }

    //******************************************************************************
    //******************************************************************************

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
        Shell.Current.GoToAsync("//MainPage");
    }

    //******************************************************************************
    //******************************************************************************

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TimeVVModel).RefreshTimeList();
    }
}
