using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
	public class BillVVModel : INotifyPropertyChanged
    {
		public BillVVModel()
		{
		}

        public BillVVModel(int clientId)
        {
            ClientId = clientId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int ClientId { get; set; }

        //******************************************************************************
        //*****************************BILLS LIST*************************

        public ObservableCollection<TimeViewModel> Bills
        {
            get
            {
                if (ClientId == 0)
                {
                    return new ObservableCollection<TimeViewModel>(TimeService.Current.Times.Select(b => new TimeViewModel(b)).ToList());
                }

                List<Time> temp = new List<Time>();

                for (int i = 0; i < TimeService.Current.Times.Count; i++)
                {
                    if (TimeService.Current.Times[i].ClientId == ClientId)
                    {
                        temp.Add(TimeService.Current.Times[i]);
                    }
                }

                return new ObservableCollection<TimeViewModel>(temp.Select(b => new TimeViewModel(b)).ToList());
            }
        }

        //******************************************************************************
        //********************************DEFINITION************************************

        public void RefreshTimeList()
        {
            NotifyPropertyChanged(nameof(Bills));
        }
    }
}

