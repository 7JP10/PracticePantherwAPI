using System;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
	public class BillService
	{
        private static BillService? instance;

        public static BillService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillService();
                }
                return instance;
            }
        }


        public BillService()
		{
            bills = new List<Bill>();
            /*{
                new Bill{BillNumber = 1, TotalAmmount = 2, ProjectId = 1, ClientId = 1},
                new Bill{BillNumber = 2, TotalAmmount = 10.0, ProjectId = 1, ClientId = 2},
                new Bill{BillNumber = 3, TotalAmmount = 20.50, ProjectId = 2, ClientId = 3}
            };*/

        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        private List<Bill> bills;

        public List<Bill> Bills
        {
            get
            {
                return bills;
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public Bill? Get(int billNum)
        {
            return Bills.FirstOrDefault(c => c.BillNumber == billNum);
        }

        public void Add(Bill b)
        {
            if (bills.Count == 0)
            {
                b.BillNumber = 1;
                bills.Add(b);
            }
            else
            {
                b.BillNumber = bills[bills.Count - 1].BillNumber + 1;
                bills.Add(b);
            }

            //ProjectService.Current.UpdateActiveStatus(StatusOfProject(c.ProjectId), c.ProjectId);
        }

        public void Update(Bill b)
        {
            for (int i = 0; i < bills.Count; i++)
            {
                if (bills[i].BillNumber == b.BillNumber)
                {
                    bills[i].TotalAmmount = b.TotalAmmount;
                    bills[i].DueDate = b.DueDate;
                }
            }
        }

        public void Delete(int id)
        {
            var billToDelete = Bills.FirstOrDefault(c => c.BillNumber == id);
            if (billToDelete != null)
            {
                for (int i = 0; i < Bills.Count; i++)
                {
                    if (Bills[i].BillNumber == id)
                    {
                        //if (Bills[i].IsActive == false)
                        //{
                            //int clientId = Bills[i].ClientId;
                            Bills.Remove(billToDelete);
                            //ClientService.Current.UpdateActiveStatus(StatusOfClient(clientId), clientId);
                        //}
                    }
                }
            }
        }
    }
}

