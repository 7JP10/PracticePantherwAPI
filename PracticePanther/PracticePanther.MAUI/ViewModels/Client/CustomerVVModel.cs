using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientVVModel : INotifyPropertyChanged
    {
        public ClientVVModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //******************************************************************************
        //***********************************ELEMENTS***********************************

        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                if (string.IsNullOrEmpty(QueryClient))
                {
                    return new ObservableCollection<ClientViewModel>(ClientService.Current.Clients.Select(c => new ClientViewModel(c)).ToList());
                }

                List<Client> temp = ClientService.Current.Search(QueryClient);

                return new ObservableCollection<ClientViewModel>(temp.Select(c => new ClientViewModel(c)).ToList());
            }
        }

        public Client SelectedClient { get; set; }

        public string QueryClient { get; set; }

        //******************************************************************************
        //********************************DEFINITION************************************

        public void SearchClient()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }


    }
}

