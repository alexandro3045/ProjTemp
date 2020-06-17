using Aplicacao.Application.DTOs;
using Aplicacao.Domain.Model;
using Aplicacao.Domain.Shared.Model;
using AutoMapper;
using System.Linq;

namespace Aplicacao.Application.AutoMapperConfigs
{
    public class AplicacaoProfile : Profile
    {
        public AplicacaoProfile()
        {
            //Address
            CreateMap<AddressDTO, Address>()
                .ForMember(m => m.Id, vm => vm.MapFrom(src => src.Id))
                .ForMember(m => m.Country, vm => vm.MapFrom(src => src.Pais))
                .ForMember(m => m.State, vm => vm.MapFrom(src => src.Estado))
                .ForMember(m => m.City, vm => vm.MapFrom(src => src.Cidade))
                .ForMember(m => m.Neighborhood, vm => vm.MapFrom(src => src.Bairro))
                .ForMember(m => m.Street, vm => vm.MapFrom(src => src.Rua))
                .ForMember(m => m.Number, vm => vm.MapFrom(src => src.Numero))
                .ForMember(m => m.Complement, vm => vm.MapFrom(src => src.Complemento))
                .ForMember(m => m.ZipCode, vm => vm.MapFrom(src => src.CEP));

            CreateMap<Address, AddressDTO>()
                .ForMember(m => m.Pais, vm => vm.MapFrom(src => src.Country))
                .ForMember(m => m.Estado, vm => vm.MapFrom(src => src.State))
                .ForMember(m => m.Cidade, vm => vm.MapFrom(src => src.City))
                .ForMember(m => m.Bairro, vm => vm.MapFrom(src => src.Neighborhood))
                .ForMember(m => m.Rua, vm => vm.MapFrom(src => src.Street))
                .ForMember(m => m.Numero, vm => vm.MapFrom(src => src.Number))
                .ForMember(m => m.Complemento, vm => vm.MapFrom(src => src.Complement))
                .ForMember(m => m.CEP, vm => vm.MapFrom(src => src.ZipCode));

            //Customer
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NomeCompleto))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RegistrationDate, opt => opt.Ignore())
                .ReverseMap();


            //Product
            CreateMap<ProductDTO, Product>()
                .ConstructUsing(c => new Product(c.Descricao, c.Peso, c.SKU, c.Preco));

            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.Id, e => e.MapFrom(src => src.Id))
                .ForMember(p => p.Descricao, e => e.MapFrom(src => src.Description))
                .ForMember(p => p.Peso, e => e.MapFrom(src => src.Weight))
                .ForMember(p => p.Preco, e => e.MapFrom(src => src.Price))
                .ForMember(p => p.SKU, e => e.MapFrom(src => src.SKU));

            //Order
            CreateMap<OrderDTO, Order>()
                .ForMember(m => m.Id, vm => vm.MapFrom(src => src.Id))
                .ForPath(dest => dest.Customer.Id, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItemsDTO))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ReverseMap();

            CreateMap<OrderItemDTO, OrderItems>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                 .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                 .ForPath(dest => dest.Order.Customer.Id, opt => opt.Ignore())
                 .ReverseMap();
        }
    }
}