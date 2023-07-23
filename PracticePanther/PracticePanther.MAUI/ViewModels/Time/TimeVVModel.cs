using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
	public class TimeVVModel : INotifyPropertyChanged
    {

        //***********************PROPERTY CHNAGED//***********************

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimeVVModel()
		{
		}

        //******************************************************************************
        //***********************************ELEMENTS***********************************

        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                /*if (string.IsNullOrEmpty(QueryClient))
                {
                    return new ObservableCollection<ClientViewModel>(ClientService.Current.Clients.Select(c => new ClientViewModel(c)).ToList());
                }

                List<Client> temp = ClientService.Current.Search(QueryClient);

                return new ObservableCollection<ClientViewModel>(temp.Select(c => new ClientViewModel(c)).ToList());*/

                //if (string.IsNullOrEmpty(QueryTime))
                //{
                    return new ObservableCollection<TimeViewModel>(TimeService.Current.Times.Select(c => new TimeViewModel(c)).ToList());
                //}

                //List<Time> temp = TimeService.Current.Search(QueryTime);

                //return new ObservableCollection<EmployeeViewModel>(temp.Select(c => new EmployeeViewModel(c)).ToList());
            }
        }

        public Time SelectedEmployee { get; set; }

        public string QueryTime { get; set; }

        //******************************************************************************
        //********************************DEFINITION************************************

        public void SearchTime()
        {
            NotifyPropertyChanged(nameof(Times));
        }

        public void RefreshTimeList()
        {
            NotifyPropertyChanged(nameof(Times));
        }
    }
}

