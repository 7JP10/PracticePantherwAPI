using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class EmployeeVVModel : INotifyPropertyChanged
    {
        //***********************PROPERTY CHNAGED//***********************

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EmployeeVVModel()
        {
        }

        //******************************************************************************
        //***********************************ELEMENTS***********************************

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(QueryEmployee))
                {
                    return new ObservableCollection<EmployeeViewModel>(EmployeeService.Current.Employees.Select(c => new EmployeeViewModel(c)).ToList());
                }

                List<Employee> temp = EmployeeService.Current.Search(QueryEmployee);

                return new ObservableCollection<EmployeeViewModel>(temp.Select(c => new EmployeeViewModel(c)).ToList());
            }
        }

        public Employee SelectedEmployee { get; set; }

        public string QueryEmployee { get; set; }

        //******************************************************************************
        //********************************DEFINITION************************************

        public void SearchEmployee()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }
    }
}

