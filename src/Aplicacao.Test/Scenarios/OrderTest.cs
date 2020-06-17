using Aplicacao.Test.Scenarios.Base.CRUD;
using System;

namespace Aplicacao.Test.Scenarios
{
    public class OrderTest : Operations
    {
        public OrderTest()
        {
            Body = new
            {
              CustomerId = 1,
              Customer = new
              {
                  NomeCompleto = "Felipe Apresentacao",
                  Address = new dynamic[] {
                    new {
                        Pais = "Brasil",
                        Estado = "Rio de Janeiro",
                        Cidade = "Rio de Janeiro",
                        Bairro = "Ipanema",
                        Rua = "Assis Brasil",
                        Numero = "34",
                        CEP = "22021030"
                    }
                  },
                  DataNascimento = DateTime.ParseExact("2020-06-14 14:43:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                  DataCadastro = DateTime.ParseExact("2020-06-14 14:43:52", "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                  Email = "felipementel@hotmail.com"
               },
                OrderItemsDTO = new dynamic[] {
                new {
                  ProductId = 1,
                  Quantity = 1,
                  Price = 12.00
                }
              }
            };
            Configure("Orders", "1");
        }
    }
}
