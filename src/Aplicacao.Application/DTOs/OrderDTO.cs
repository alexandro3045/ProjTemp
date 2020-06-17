﻿using Aplicacao.Domain.Model;
using System.Collections.Generic;

namespace Aplicacao.Application.DTOs
{
    public class OrderDTO : BaseDTOEntity<int>
    {
        public int CustomerId { get; set; }

        public CustomerDTO Customer { get; set; }

        public List<OrderItemDTO> OrderItemsDTO { get; set; }
    }
}
