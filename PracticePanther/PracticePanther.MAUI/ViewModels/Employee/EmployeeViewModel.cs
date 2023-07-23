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
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        //***********************PROPERTY CHNAGED//***********************

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //****************************CONSTRUCTORS**************************

        public EmployeeViewModel()
        {
            Model = new Employee();
            SetupCommands();
        }

        public EmployeeViewModel(Employee employee)
        {
            Model = employee;
            SetupCommands();
        }

        public EmployeeViewModel(int id)
        {
            Model = EmployeeService.Current.Get(id);

            Name = EmployeeService.Current.Name(id);
            Rate = EmployeeService.Current.Rate(id);

            SetupCommands();
        }

        //*****************************ELEMENTS******************************

        public Employee Model { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }

        public ICommand ViewEmployeeCommand { get; private set; }
        public ICommand EditEmployeeCommand { get; private set; }
        public ICommand DeleteEmployeeCommand { get; private set; }

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
            EmployeeService.Current.Add(Model);
        }

        public void Update()
        {
            Model.Name = Name;
            Model.Rate = Rate;

            EmployeeService.Current.Update(Model);
        }

        //**********************************************************
        //*************************COMMANDS*************************
        //**********************************************************

        private void SetupCommands()
        {
            ViewEmployeeCommand = new Command(
                (c) => ExecuteViewEmployee((c as EmployeeViewModel).Model.Id));

            EditEmployeeCommand = new Command(
                (c) => ExecuteEditEmployee((c as EmployeeViewModel).Model.Id));

            DeleteEmployeeCommand = new Command(
                (c) => ExecuteDeleteEmployee((c as EmployeeViewModel).Model.Id));
        }

        public void ExecuteViewEmployee(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//EmployeeView?employeeId={id}");
        }

        public void ExecuteEditEmployee(int id)
        {
            if (id < 0 || id == 0) { id = 0; }
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={id}");
        }

        public void ExecuteDeleteEmployee(int id)
        {
            EmployeeService.Current.Delete(id);
        }

    }
}

