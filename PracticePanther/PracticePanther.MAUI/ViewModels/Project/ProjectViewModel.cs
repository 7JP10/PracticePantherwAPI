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
    public class ProjectViewModel : INotifyPropertyChanged
    {
        //***********************PROPERTY CHNAGED//***********************

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //****************************CONSTRUCTORS**************************

        public ProjectViewModel()
        {
            Model = new Project();

            SetupCommands();
        }

        public ProjectViewModel(Project project)
        {
            Model = project;

            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {
            Model = new Project();

            Model.ClientId = clientId;
            SetupCommands();
        }

        public ProjectViewModel(int projectId, bool flag)
        {
            Model = ProjectService.Current.Get(projectId);

            OpenDate = ProjectService.Current.OpenDate(projectId);
            ClosedDate = ProjectService.Current.ClosedDate(projectId);

            if (ProjectService.Current.ActiveStatus(projectId) == false)
            {
                IsActiveStatusVisible = true;
            }
            else
            {
                IsActiveStatusVisible = false;
            }

            Name = ProjectService.Current.Name(projectId);
            Abbreviation = ProjectService.Current.Abbreviation(projectId);

            SetupCommands();
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
                    if (BillService.Current.Bills[i].ProjectId == Model.Id)
                    {
                        temp.Add(BillService.Current.Bills[i]);
                    }
                }

                return new ObservableCollection<BillViewModel>(temp.Select(b => new BillViewModel(b)).ToList());
            }
        }

        //*****************************ELEMENTS******************************

        public Project Model { get; set; }

        public ICommand ViewProjectCommand { get; private set; }
        public ICommand EditProjectCommand { get; private set; }
        public ICommand DeleteProjectCommand { get; private set; }

        public string ActiveStatus { get; private set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
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

            ProjectService.Current.Add(Model);
        }

        public void Update()
        {
            Model.LongName = Name;
            Model.ShortName = Abbreviation;
            ProjectService.Current.Update(Model);
        }

        public void RefreshBillList()
        {
            NotifyPropertyChanged(nameof(Bills));
        }

        //**********************************************************
        //*************************COMMANDS*************************
        //**********************************************************

        private void SetupCommands()
        {
            ViewProjectCommand = new Command(
                (c) => ExecuteViewProject((c as ProjectViewModel).Model.Id));

            EditProjectCommand = new Command(
                (c) => ExecuteEditProject((c as ProjectViewModel).Model.Id));

            DeleteProjectCommand = new Command(
                (c) => ExecuteDeleteProject((c as ProjectViewModel).Model.Id));
        }

        public void ExecuteViewProject(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//ProjectView?projectId={id}");
        }

        public void ExecuteEditProject(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//ProjectDetail?projectId={id}");
        }

        public void ExecuteDeleteProject(int id) // cannot delete if project is active 
        {
            ProjectService.Current.Delete(id);
        }

    }
}

