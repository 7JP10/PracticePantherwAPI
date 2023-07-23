using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        //***********************PROPERTY CHNAGED//***********************

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //****************************CONSTRUCTORS**************************

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();
        }

        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            Model = ClientService.Current.Get(clientId);

            OpenDate = ClientService.Current.OpenDate(clientId);
            ClosedDate = ClientService.Current.ClosedDate(clientId);

            if (ClientService.Current.ActiveStatus(clientId) == false)
            {
                IsActiveStatusVisible = true;
            }
            else
            {
                IsActiveStatusVisible = false;
            }

            Name = ClientService.Current.Name(clientId);
            Notes = ClientService.Current.Notes(clientId);


            SetupCommands();
        }

        //*****************************PROJECT LIST*************************

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Projects.Select(p => new ProjectViewModel(p)).ToList());
                    //return new ObservableCollection<ProjectViewModel>();
                }

                List<Project> temp = new List<Project>();

                for (int i = 0; i < ProjectService.Current.Projects.Count; i++)
                {
                    if (ProjectService.Current.Projects[i].ClientId == Model.Id)
                    {
                        temp.Add(ProjectService.Current.Projects[i]);
                    }
                }

                return new ObservableCollection<ProjectViewModel>(temp.Select(p => new ProjectViewModel(p)).ToList());

            }
        }

        //*****************************BILLS LIST*************************

        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>(BillService.Current.Bills.Select(b => new BillViewModel(b)).ToList());
                }

                List<Bill> temp = new List<Bill>();

                for (int i = 0; i < BillService.Current.Bills.Count; i++)
                {
                    if (BillService.Current.Bills[i].ClientId == Model.Id)
                    {
                        temp.Add(BillService.Current.Bills[i]);
                    }
                }

                return new ObservableCollection<BillViewModel>(temp.Select(b => new BillViewModel(b)).ToList());
            }
        }

        //*****************************ELEMENTS******************************

        public Client Model { get; set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }

        public ICommand ManageProjectCommand { get; private set; }
        public ICommand ManageBillsCommand { get; private set; }

        public string Name { get; set; }
        public string Notes { get; set; }
        public string OpenDate { get; set; }
        public string ClosedDate { get; private set; }
        public bool IsActiveStatusVisible { get; set; }

        //*******************************METHODS*******************************

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void Add()
        {
            Model.IsActive = false;
            Model.OpenDate = DateTime.Now;
            Model.ClosedDate = DateTime.Now;

            ClientService.Current.Add(Model);
        }

        public void Update()
        {
            Model.Name = Name;
            Model.Notes = Notes;
            ClientService.Current.Update(Model);
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
            NotifyPropertyChanged(nameof(Bills));
        }

        //**********************************************************
        //*************************COMMANDS*************************
        //**********************************************************

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));

            EditCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));

            ViewCommand = new Command(
                (c) => ExecuteView((c as ClientViewModel).Model.Id));


            ManageProjectCommand = new Command(
                (c) => ExecuteManageProject((c as ClientViewModel).Model.Id));

            ManageBillsCommand = new Command(
                (c) => ExecuteManageBills((c as ClientViewModel).Model.Id));

        }

        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id); // can only delete when client is inactive
        }

        public void ExecuteEdit(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        public void ExecuteView(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//ClientView?clientId={id}");
        }

        public void ExecuteManageProject(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//ManageProject?clientId={id}");
        }

        public void ExecuteManageBills(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//TimeManage?clientId={id}");
        }

    }
}

