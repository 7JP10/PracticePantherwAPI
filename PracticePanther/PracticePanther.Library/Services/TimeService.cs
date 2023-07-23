using System;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
	public class TimeService
	{

        private static TimeService? instance;

        public static TimeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimeService();
                }
                return instance;
            }
        }

        private TimeService()
        {
            times = new List<Time>();
            /*{
                new Time{EntryNumber = 1, EmployeeId = 1, ProjectId = 1, Rate = 2, ClientId = 1},
                new Time{EntryNumber = 2, EmployeeId = 2, ProjectId = 2, Rate = 0.0m, ClientId = 1},
                new Time{EntryNumber = 3, EmployeeId = 3, ProjectId = 3, Rate = 5.0m, ClientId = 2}
            };*/
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        private List<Time> times;

        public List<Time> Times
        {
            get
            {
                return times;
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public Time? Get(int entryNum)
        {
            return Times.FirstOrDefault(c => c.EntryNumber == entryNum);
        }

        /*public List<Time> Search(string queryTime)
        {
            return times.Where(c => c.Name.ToUpper().Contains(queryEmployee.ToUpper())).ToList();
        }*/

        public void Add(Time c)
        {
            if (times.Count == 0)
            {
                c.EntryNumber = 1;
                times.Add(c);
            }
            else
            {
                c.EntryNumber = times[times.Count - 1].EntryNumber + 1;
                times.Add(c);
            }

            ProjectService.Current.UpdateActiveStatus(StatusOfProject(c.ProjectId), c.ProjectId);
        }

        public bool StatusOfProject(int projectId)
        {
            int count = 0;

            for (int i = 0; i < Times.Count; i++)
            {
                if (Times[i].ProjectId == projectId)
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

        public void Update(Time c, int oldProjectID)
        {
            for (int i = 0; i < times.Count; i++)
            {
                if (times[i].EntryNumber == c.EntryNumber)
                {
                    times[i].EmployeeId = c.EmployeeId;
                    times[i].ProjectId = c.ProjectId;
                    times[i].Narrative = c.Narrative;
                    times[i].Rate = c.Rate;
                    times[i].Date = c.Date;
                }
            }

            ProjectService.Current.UpdateActiveStatus(StatusOfProject(c.ProjectId), c.ProjectId);
            ProjectService.Current.UpdateActiveStatus(StatusOfProject(oldProjectID), oldProjectID);
        }

        public void Delete(int id)
        {
            var timeToDelete = Times.FirstOrDefault(c => c.EntryNumber == id);
            if (timeToDelete != null)
            {
                for (int i = 0; i < Times.Count; i++)
                {
                    if (Times[i].EntryNumber == id)
                    {
                        int projectId = Times[i].ProjectId;
                        Times.Remove(timeToDelete);
                        ProjectService.Current.UpdateActiveStatus(StatusOfProject(projectId), projectId);
                    }
                }
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public string Date(int id)
        {
            string oDate = "";
            var c = Get(id);

            if (c == null)
            {
                return "";
            }

            oDate = c.Date.Month.ToString();
            oDate += "/" + c.Date.Day.ToString();
            oDate += "/" + c.Date.Year.ToString();

            return oDate;
        }

        public string Narrative(int id)
        {
            var c = Get(id);

            if (c == null || c.Narrative == null)
            {
                return "";
            }

            return c.Narrative;
        }

        public int EmployeeId(int id)
        {
            var c = Get(id);

            if (c == null)
            {
                return 0;
            }

            return c.EmployeeId;
        }

        public int ProjectId(int id)
        {
            var c = Get(id);

            if (c == null)
            {
                return 0;
            }

            return c.ProjectId;
        }

        public int Hours(int id)
        {
            var c = Get(id);

            if (c == null)
            {
                return 0;
            }

            return c.Hours;
        }

        public decimal Rate(int id)
        {
            var c = Get(id);

            if (c == null)
            {
                return 0;
            }

            return c.Rate;
        }

        public int EntryNum(int id)
        {
            var c = Get(id);

            if (c == null)
            {
                return 0;
            }

            return c.EntryNumber;
        }
    }
}

