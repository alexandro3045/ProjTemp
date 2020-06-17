using Aplicacao.Domain.Shared.Model;
using System;
using System.Collections.Generic;
namespace Aplicacao.Domain.Model
{
    public class Customer : TEntity<int>
    {
        public Customer()
        {
           
        }

        public Customer(string name, string email, DateTime birthDate, ICollection<Address> addresses)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            RegistrationDate = DateTime.Now;
            Address = addresses;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public DateTime RegistrationDate { get; private set; } = DateTime.Now;

        public ICollection<Address> Address { get; set; }
    }
}