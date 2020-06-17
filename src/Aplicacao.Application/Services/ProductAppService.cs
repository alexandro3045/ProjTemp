using Aplicacao.Application.DTOs;
using Aplicacao.Application.Interfaces;
using Aplicacao.Domain.Interfaces.Services;
using Aplicacao.Domain.Model;
using AutoMapper;

namespace Aplicacao.Application.Services
{
    public class ProductAppService : BaseAppService<Product, ProductDTO, int>, IProductAppService
    {
        public ProductAppService(IProductService appService, IMapper mapper) : base(appService, mapper) { }
    }
}