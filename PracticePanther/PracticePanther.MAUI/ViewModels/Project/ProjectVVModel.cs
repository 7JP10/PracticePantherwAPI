using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectVVModel : INotifyPropertyChanged
    {
        public ProjectVVModel()
        {
        }

        public ProjectVVModel(int clientId)
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
        //*******************************PROJECT LIST***********************************

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (string.IsNullOrEmpty(QueryProject))
                {
                    if (ClientId == 0)
                    {
                        return new ObservableCollection<ProjectViewModel>(ProjectService.Current.Projects.Select(p => new ProjectViewModel(p)).ToList());
                        //return new ObservableCollection<ProjectViewModel>();
                    }

                    List<Project> temp = new List<Project>();

                    for (int i = 0; i < ProjectService.Current.Projects.Count; i++)
                    {
                        if (ProjectService.Current.Projects[i].ClientId == ClientId)
                        {
                            temp.Add(ProjectService.Current.Projects[i]);
                        }
                    }

                    return new ObservableCollection<ProjectViewModel>(temp.Select(p => new ProjectViewModel(p)).ToList());
                }

                List<Project> temp3 = new List<Project>();

                for (int i = 0; i < ProjectService.Current.Projects.Count; i++)
                {
                    if (ProjectService.Current.Projects[i].ClientId == ClientId)
                    {
                        temp3.Add(ProjectService.Current.Projects[i]);
                    }
                }

                List<Project> temp2 = ProjectService.Current.Search(QueryProject, temp3);

                return new ObservableCollection<ProjectViewModel>(temp2.Select(c => new ProjectViewModel(c)).ToList());
            }
        }

        public Project SelectedProject { get; set; }

        public string QueryProject { get; set; }

        //******************************************************************************
        //********************************DEFINITION************************************

        public void SearchProject()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
    }
}

