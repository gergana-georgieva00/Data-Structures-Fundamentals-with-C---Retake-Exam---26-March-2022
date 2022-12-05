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
            if (this.barbers.Any(ba => ba.Name == b.Name))
            {
                throw new ArgumentException();
            }

            this.barbers.Add(b);
        }

        public void AddClient(Client c)
        {
            if (this.clients.Any(cl => cl.Name == cl.Name))
            {
                throw new ArgumentException();
            }

            this.clients.Add(c);
        }

        public bool Exist(Barber b)
            => this.barbers.Any(ba => ba.Name == b.Name);

        public bool Exist(Client c)
            => this.clients.Any(cl => cl.Name == c.Name);

        public IEnumerable<Barber> GetBarbers()
            => this.barbers;

        public IEnumerable<Client> GetClients()
            => this.clients;

        public void AssignClient(Barber b, Client c)
        {
            if (this.barbers.ContainsKey(b) && this.clients.Any(cl => cl.Name == c.Name))
            {
                var client = this.clients.Find(cl => cl.Name == c.Name);
                barbers[b].Add(client);
                client.Barber = b;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            if (!this.barbers.ContainsKey(b))
            {
                throw new ArgumentException();
            }

            this.barbers[b] = new List<Client>();
        }

        public IEnumerable<Client> GetClientsWithNoBarber()
            => this.clients.Where(c => c.Barber is null);

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
        {
            //var sorted = from entry in barbers orderby entry.Value.Count descending select entry.Key;
            var barbersFiltered = new List<Barber>();

            foreach (var barber in barbers.OrderByDescending(b => b.Value.Count))
            {
                barbersFiltered.Add(barber.Key);
            }

            return barbersFiltered;
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
            => this.barbers.Keys.OrderByDescending(b => b.Stars).ThenBy(b => b.HaircutPrice);

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
            => this.clients.Where(c => c.Barber != null).OrderByDescending(c => c.Age).ThenByDescending(c => c.Barber.Stars);
    }
}
