using System;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;

        public static EmployeeService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return instance;
            }
        }

        private EmployeeService()
        {
            employees = new List<Employee>
            {
                new Employee{Id = 1, Name = "Jose", Rate = 2.0m},
                new Employee{Id = 2, Name = "Edward", Rate = 0.0m},
                new Employee{Id = 3, Name = "Joshua", Rate = 5.0m}
            };
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        private List<Employee> employees;

        public List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public Employee? Get(int id)
        {
            return Employees.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Employee c)
        {
            if (employees.Count == 0)
            {
                c.Id = 1;
                employees.Add(c);
            }
            else
            {
                c.Id = employees[employees.Count - 1].Id + 1;
                employees.Add(c);
            }

        }

        public List<Employee> Search(string queryEmployee)
        {
            return employees.Where(c => c.Name.ToUpper().Contains(queryEmployee.ToUpper())).ToList();
        }

        public void Update(Employee c)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (c.Id == employees[i].Id)
                {
                    employees[i].Name = c.Name;
                    employees[i].Rate = c.Rate;
                }
            }
        }

        public void Delete(int id)
        {
            var employeeToDelete = Employees.FirstOrDefault(c => c.Id == id);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public string Name(int id)
        {
            var c = Get(id);

            if (c == null || c.Name == null)
            {
                return "";
            }

            return c.Name;
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

    }
}

