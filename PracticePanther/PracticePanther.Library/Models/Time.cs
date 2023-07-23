using System;
using System.Reflection;
using System.Xml.Linq;

namespace PracticePanther.Library.Models
{
    public class Time
    {
        public Time()
        {
            EntryNumber = 0;
            Date = DateTime.Now;
            Narrative = "";
            Hours = 0;
            ProjectId = 0;
            EmployeeId = 0;
            Rate = 0;
        }

        public override string ToString()
        {
            if (Hours > 0)
            {
                double total = (double)(Hours * Rate);
                string t1 = Date.ToShortDateString();
                return $"{EntryNumber}) Proj.ID: {ProjectId}  Emp.ID: {EmployeeId}  Hours: {Hours} | Total Amount Due: ${total}   Pay By:  {t1}  ";
            }

            return $"{EntryNumber}) Proj.ID: {ProjectId}  Emp.ID: {EmployeeId}  Hours: {Hours}";

        }

        public int EntryNumber { get; set; }

        public DateTime Date { get; set; }

        public string? Narrative { get; set; }

        public int Hours { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }


        public decimal Rate { get; set; }

        public int ClientId { get; set; }
    }
}