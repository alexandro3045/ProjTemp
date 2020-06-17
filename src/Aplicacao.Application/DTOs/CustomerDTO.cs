using System;
using System.Collections.Generic;

namespace Aplicacao.Application.DTOs
{
    public class CustomerDTO : BaseDTOEntity<int>
    {
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public ICollection<AddressDTO> Address { get; set; }
    }
}