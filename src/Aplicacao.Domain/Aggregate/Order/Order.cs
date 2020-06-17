using Aplicacao.Domain.Shared.Model;
using System.Collections.Generic;

namespace Aplicacao.Domain.Model
{
    public class Order : TEntity<int>
    {
        public virtual int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
