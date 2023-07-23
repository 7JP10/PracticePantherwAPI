using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticePanther.Library.Models
{
    public class Employee
    {
        public Employee()
        {
            Id = 0;
            Name = "";
            Rate = 0;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Rate { get; set; }

        public override string ToString()
        {
            return $"{Id}) {Name}";
        }

    }
}