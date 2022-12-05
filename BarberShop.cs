﻿using System;
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
            if (this.barbers.Any(b => b.Name == b.Name))
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
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void AssignClient(Barber b, Client c)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllClientsFrom(Barber b)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClientsWithNoBarber()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
        {
            throw new NotImplementedException();
        }
    }
}
