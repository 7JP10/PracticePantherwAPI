using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticePanther.Library.Models
{
    public class Client
    {
        public override string ToString()
        {
            if (IsActive == true)
            {
                return $"{Id} {Name}";
            }

            return $"{Id} {Name}           *INACTIVE*";

        }

        public Client()
        {
            Id = 0;
            Name = "";
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now;
            IsActive = false;
            Notes = "";
        }

        //*********FIELDS**********

        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime ClosedDate { get; set; }

        public bool IsActive { get; set; }

        public string? Notes { get; set; }
    }
}