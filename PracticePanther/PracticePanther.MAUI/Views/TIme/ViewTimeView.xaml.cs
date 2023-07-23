using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EntryNumber), "entryNumber")]
public partial class ViewTimeView : ContentPage
{
	public ViewTimeView()
	{
		InitializeComponent();
	}

    public int EntryNumber { get; set; }

    //************************************************************************
    //************************************************************************
    //************************************************************************

    public void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ManageTime");
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
            Shell.Current.GoToAsync("//ManageTime");
        }

    }

    private void OnLeaving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = null;
    }
}
