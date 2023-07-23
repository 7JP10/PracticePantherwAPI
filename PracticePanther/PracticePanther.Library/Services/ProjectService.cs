using PracticePanther.Library.Models;
using System;
using System.Reflection;

namespace PracticePanther.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;

        public static ProjectService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }
                return instance;
            }
        }


        private ProjectService()
        {
            projects = new List<Project>
              {
                new Project{Id = 1, ClientId = 1, IsActive = false, ShortName = "FREE", LongName = "Free YNW Melly", OpenDate = new DateTime(2019,05,09,09,15,00)},
                new Project{Id = 2, ClientId = 2, IsActive = false, ShortName = "X Trial", LongName = "XXXTentacion Murder Trial", OpenDate = new DateTime(2019,05,09,09,15,00)},
                new Project{Id = 3, ClientId = 3, IsActive = false, ShortName = "Custody", LongName = "Shelby Custy Trial", OpenDate = new DateTime(2019,05,09,09,15,00)}
            };
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        private List<Project> projects;

        public List<Project> Projects
        {
            get
            {
                return projects;
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public Project? Get(int id)
        {
            return Projects.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Project p)
        {
            if (projects.Count == 0)
            {
                p.Id = 1;
                projects.Add(p);
            }
            else
            {
                p.Id = projects[projects.Count - 1].Id + 1;
                projects.Add(p);
            }

            ClientService.Current.UpdateActiveStatus(StatusOfClient(p.ClientId), p.ClientId);

        }

        public bool StatusOfClient(int id)
        {

            int count = 0;

            for (int i = 0; i < Projects.Count; i++)
            {
                //if ((Projects[i].ClientId) == id) ORGINAL
                if ((Projects[i].ClientId) == id && (Projects[i].IsActive) == true)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return false;
            }

            return true;
        }

        public void Update(Project c)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (c.Id == projects[i].Id)
                {
                    projects[i].LongName = c.LongName;
                    projects[i].ShortName = c.ShortName;
                }
            }
        }

        public void UpdateActiveStatus(bool aS, int projectId)
        {
            for (int i = 0; i < projects.Count; i++)
            {
                if (projectId == projects[i].Id)
                {
                    projects[i].IsActive = aS;
                    ClientService.Current.UpdateActiveStatus(StatusOfClient(projects[i].ClientId), projects[i].ClientId);
                    if (projects[i].IsActive == false)
                    {
                        projects[i].ClosedDate = DateTime.Now;
                    }
                }
            }
        }

        public List<Project> Search(string queryClient, List<Project> temp)
        {
            return temp.Where(c => c.LongName.ToUpper().Contains(queryClient.ToUpper())).ToList();
        }

        public List<Project> Search(string queryClient)
        {
            return projects.Where(c => c.LongName.ToUpper().Contains(queryClient.ToUpper())).ToList();
        }

        public void Delete(int id)
        {
            var clientToDelete = Projects.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                for (int i = 0; i < Projects.Count; i++)
                {
                    if (Projects[i].Id == id)
                    {
                        if (Projects[i].IsActive == false)
                        {
                            int clientId = Projects[i].ClientId;
                            Projects.Remove(clientToDelete);
                            ClientService.Current.UpdateActiveStatus(StatusOfClient(clientId), clientId);
                        }
                    }
                }
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public string OpenDate(int id)
        {
            string oDate = "";
            var c = Get(id);

            if (c == null)
            {
                return "";
            }

            oDate = c.OpenDate.Month.ToString();
            oDate += "/" + c.OpenDate.Day.ToString();
            oDate += "/" + c.OpenDate.Year.ToString();

            return oDate;
        }

        public string ClosedDate(int id)
        {
            string cDate = "";
            var c = Get(id);

            if (c == null)
            {
                return "";
            }

            cDate = c.ClosedDate.Month.ToString();
            cDate += "/" + c.ClosedDate.Day.ToString();
            cDate += "/" + c.ClosedDate.Year.ToString();

            return cDate;
        }

        public bool ActiveStatus(int id)
        {
            var c = Get(id);

            if (c == null)
            {
                return false;
            }

            if (c.IsActive == true)
            {
                return true;
            }

            return false;
        }

        public string Name(int id)
        {
            var c = Get(id);

            if (c == null || c.LongName == null)
            {
                return "";
            }

            return c.LongName;
        }

        public string Abbreviation(int id)
        {
            var c = Get(id);

            if (c == null || c.ShortName == null)
            {
                return "";
            }

            return c.ShortName;
        }


    }
}

