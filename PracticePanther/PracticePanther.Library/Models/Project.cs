using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Models
{
    public class Project
    {
        public Project()
        {
            Id = 0;
            ClientId = 0;
            LongName = "";
            ShortName = "";
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now;
            IsActive = false;
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? LongName { get; set; }
        public string? ShortName { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            if (IsActive == true)
            {
                return $"{Id} {LongName} ({ShortName})";
            }

            return $"{Id} {LongName} ({ShortName})         *INACTIVE*";


        }


    }
}