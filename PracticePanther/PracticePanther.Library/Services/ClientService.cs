using System.Reflection;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }
                return instance;
            }
        }

        private ClientService()
        {
            clients = new List<Client>
              {
                new Client{ Id = 1, Name = "Client 1"},
                new Client{ Id = 2, Name = "Client 2"},
                new Client{ Id = 3, Name = "Client 3"},
                new Client{ Id = 4, Name = "Client 4"},
                new Client{ Id = 5, Name = "Client 5"},
                new Client{ Id = 6, Name = "Client 6"}
            };
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        private List<Client> clients;

        public List<Client> Clients
        {
            get
            {
                return clients;
            }
        }

        //******************************************************************
        //******************************************************************
        //******************************************************************

        public Client? Get(int id)
        {
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Client c)
        {
            if (clients.Count == 0)
            {
                c.Id = 1;
                clients.Add(c);
            }
            else
            {
                c.Id = clients[clients.Count - 1].Id + 1;
                clients.Add(c);
            }

        }

        public void Update(Client c)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (c.Id == clients[i].Id)
                {
                    clients[i].Name = c.Name;
                    clients[i].Notes = c.Notes;
                }
            }
        }

        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                if (clientToDelete.IsActive == false)
                {
                    Clients.Remove(clientToDelete);
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

            if (c == null || c.Name == null)
            {
                return "";
            }

            return c.Name;
        }

        public string Notes(int id)
        {
            var c = Get(id);

            if (c == null || c.Notes == null)
            {
                return "";
            }

            return c.Notes;
        }

        public List<Client> Search(string queryClient)
        {
            return clients.Where(c => c.Name.ToUpper().Contains(queryClient.ToUpper())).ToList();
        }

        public void UpdateActiveStatus(bool aS, int clientId)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clientId == clients[i].Id)
                {
                    clients[i].IsActive = aS;
                    if (clients[i].IsActive == false)
                    {
                        clients[i].ClosedDate = DateTime.Now;
                    }
                }
            }
        }

    }
}