using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop
{
    public class BarberShop : IBarberShop
    {
        private List<Barber> barbers;
        private List<Client> clients;

        public BarberShop()
        {
            this.barbers = new List<Barber>();
            this.clients = new List<Client>();
        }

        public void AddBarber(Barber b)
        {
            if (this.barbers.Contains(b))
            {
                throw new ArgumentException();
            }

            this.barbers.Add(b);
        }

        public void AddClient(Client c)
        {
            if (this.clients.Contains(c))
            {
                throw new ArgumentException();
            }

            this.clients.Add(c);
        }

        public bool Exist(Barber b)
            => this.barbers.Contains(b);

        public bool Exist(Client c)
            => this.clients.Contains(c);

        public IEnumerable<Barber> GetBarbers()
            => this.barbers;

        public IEnumerable<Client> GetClients()
            => this.clients;

        public void AssignClient(Barber b, Client c)
        {
            if (this.barbers.Contains(b) && this.clients.Contains(c))
            {
                b.Clients.Add(c);
                c.Barber = b;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            if (!this.barbers.Contains(b))
            {
                throw new ArgumentException();
            }

            b.Clients = new List<Client>();
        }

        public IEnumerable<Client> GetClientsWithNoBarber()
            => this.clients.Where(c => c.Barber is null);

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
            => this.barbers.OrderByDescending(b => b.Clients.Count);

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
            => this.barbers.OrderByDescending(b => b.Stars).ThenBy(b => b.HaircutPrice);

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
            => this.clients.Where(c => c.Barber != null).OrderByDescending(c => c.Age).ThenByDescending(c => c.Barber.Stars);
    }
}
