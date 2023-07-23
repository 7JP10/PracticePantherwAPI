using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
	public class TimeViewModel : INotifyPropertyChanged
    {
        //***********************PROPERTY CHNAGED***********************

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //****************************LISTS**************************

        public ObservableCollection<Project> Projects
        {
            get
            {
                if (string.IsNullOrEmpty(QueryProject))
                {
                    return new ObservableCollection<Project>(ProjectService.Current.Projects);
                }
                return new ObservableCollection<Project>(ProjectService.Current.Search(QueryProject));
            }
        }

        public Project SelectedProject { get; set; }

        public string QueryProject { get; set; }

        //*-*-*-*-*-*-*-*-*-*

        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(QueryEmployee))
                {
                    return new ObservableCollection<Employee>(EmployeeService.Current.Employees);
                }
                return new ObservableCollection<Employee>(EmployeeService.Current.Search(QueryEmployee));
            }
        }

        public Employee SelectedEmployee { get; set; }

        public string QueryEmployee { get; set; }

        //****************************CONSTRUCTORS**************************

        public TimeViewModel()
        {
            Model = new Time();
            SetupCommands();
        }

        public TimeViewModel(Time timeEntry)
        {
            Model = timeEntry;
            SetupCommands();
        }

        public TimeViewModel(int id)
        {
            Model = TimeService.Current.Get(id);

            DateAndTime = TimeService.Current.Date(id);
            ProjectId = TimeService.Current.ProjectId(id);
            EmployeeId = TimeService.Current.EmployeeId(id);
            Narrative = TimeService.Current.Narrative(id);
            Hours = TimeService.Current.Hours(id);
            Rate = TimeService.Current.Rate(id);
            EntryNum = TimeService.Current.EntryNum(id);
            Total = (double)(Hours * Rate);

            //SelectedEmployee.Id = EmployeeId;
            //SelectedProject.Id = ProjectId;

            SetupCommands();
        }

        //*****************************ELEMENTS******************************

        public Time Model { get; set; }

        public ICommand ViewTimeCommand { get; private set; }
        public ICommand EditTimeCommand { get; private set; }
        public ICommand DeleteTimeCommand { get; private set; }

        public ICommand TimeInfoCommand { get; private set; }
        public ICommand TimeDetailCommand { get; private set; }

        public string DateAndTime { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int Hours { get; set; }
        public string Narrative { get; set; }
        public decimal Rate { get; set; }
        public int EntryNum { get; set; }
        public double Total { get; set; }

        //*******************************METHODS*******************************

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public void AddTime()
        {
            Model.ClientId = SelectedProject.ClientId;
            Model.EmployeeId = SelectedEmployee.Id;
            Model.ProjectId = SelectedProject.Id;
            Model.Rate = SelectedEmployee.Rate;

            DateTime userDateTime;
            if (!(DateTime.TryParse(DateAndTime, out userDateTime)))
            {
                Model.Date = DateTime.Now;
            }
            else
            {
                Model.Date = DateTime.Parse(DateAndTime);
            }

            TimeService.Current.Add(Model);

            Bill temp = new Bill();

            temp.ProjectId = SelectedProject.Id;
            temp.TotalAmmount = (double)(Model.Hours * Model.Rate);
            temp.DueDate = Model.Date;
            temp.ClientId = SelectedProject.ClientId;

            BillService.Current.Add(temp);
        }

        public void UpdateTime()
        {
            int oldProjectID = Model.ProjectId;
            if (SelectedEmployee.Id != 0 && SelectedEmployee != null)
            {
                Model.EmployeeId = SelectedEmployee.Id;
            }

            if (SelectedProject.Id != 0 && SelectedProject != null)
            {
                Model.ProjectId = SelectedProject.Id;
            }
            
            Model.Rate = SelectedEmployee.Rate;
            Model.Hours = Hours;
            Model.Narrative = Narrative;
            
            DateTime userDateTime;
            if (!(DateTime.TryParse(DateAndTime, out userDateTime)))
            {
                Model.Date = DateTime.Now;
            }
            else
            {
                Model.Date = DateTime.Parse(DateAndTime);
            }

            TimeService.Current.Update(Model, oldProjectID);

            Bill temp = new Bill();

            temp.ProjectId = SelectedProject.Id;
            temp.TotalAmmount = (double)(Model.Hours * Model.Rate);
            temp.DueDate = Model.Date;
            temp.ClientId = SelectedProject.ClientId;

            BillService.Current.Update(temp);
        }

        public void UpdateTime2()
        {
            Model.Hours = Hours;
            Model.Narrative = Narrative;

            DateTime userDateTime;
            if (!(DateTime.TryParse(DateAndTime, out userDateTime)))
            {
                Model.Date = DateTime.Now;
            }
            else
            {
                Model.Date = DateTime.Parse(DateAndTime);
            }

            TimeService.Current.Update(Model, Model.ProjectId);

            Bill temp = new Bill();
            
            temp.TotalAmmount = (double)(Model.Hours * Model.Rate);
            temp.DueDate = Model.Date;

            BillService.Current.Update(temp);
        }

        //**********************************************************
        //*************************COMMANDS*************************
        //**********************************************************

        private void SetupCommands()
        {
            ViewTimeCommand = new Command(
                (c) => ExecuteViewTime((c as TimeViewModel).Model.EntryNumber));

            EditTimeCommand = new Command(
                (c) => ExecuteEditTime((c as TimeViewModel).Model.EntryNumber));

            DeleteTimeCommand = new Command(
                (c) => ExecuteDeleteTime((c as TimeViewModel).Model.EntryNumber));

            TimeInfoCommand = new Command(
                (c) => ExecuteTimeInfo((c as TimeViewModel).Model.EntryNumber));

            TimeDetailCommand = new Command(
                (c) => ExecuteTimeDetail((c as TimeViewModel).Model.EntryNumber));
        }

        public void ExecuteViewTime(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//TimeView?entryNumber={id}");
            //Shell.Current.GoToAsync("//TimeView");
        }

        public void ExecuteEditTime(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//TimeEdit?entryNumber={id}");
            //Shell.Current.GoToAsync("//TimeEdit");
        }

        public void ExecuteDeleteTime(int id)
        {
            TimeService.Current.Delete(id);
            BillService.Current.Delete(id);
        }

        public void ExecuteTimeInfo(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//TimeInfo?entryNumber={id}");
        }

        public void ExecuteTimeDetail(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//TimeDetail?entryNumber={id}");
        }

        //**********************************************************
        //**********************************************************

        public void ClearProperties()
        {
            DateAndTime = "";
            NotifyPropertyChanged(nameof(DateAndTime));
        }

        public void RefreshLists()
        {
            NotifyPropertyChanged(nameof(Projects));
            NotifyPropertyChanged(nameof(Employees));
        }
        public void SearchEmployee()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public void SearchProject()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}

