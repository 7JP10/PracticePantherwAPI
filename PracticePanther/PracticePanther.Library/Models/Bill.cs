using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticePanther.Library.Models
{
	public class Bill
	{
		public Bill()
		{
            BillNumber = 0;
            DueDate = DateTime.Now;
            TotalAmmount = 0.0;
        }

        public override string ToString()
        {
            string t1 = DueDate.ToShortDateString();
            return $"{BillNumber})  Proj.ID: {ProjectId} | Total Amount Due: ${TotalAmmount}  Pay By:  {t1}";
        }

        public int BillNumber { get; set; }

        public DateTime DueDate { get; set; }

		public Double TotalAmmount { get; set; }

        public int ProjectId { get; set; }

        public int ClientId { get; set; }
    }
}

