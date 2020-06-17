using Aplicacao.Domain.Shared.Model;

namespace Aplicacao.Domain.Model
{
    public class Address : TEntity<int>
    {
        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; private set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }
    }
}
