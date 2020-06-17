using Aplicacao.Application.DTOs;
using Aplicacao.Application.Interfaces;
using Aplicacao.Domain.Interfaces.Services;
using Aplicacao.Domain.Model;
using AutoMapper;

namespace Aplicacao.Application.Services
{
    public class CustomerAppService : BaseAppService<Customer, CustomerDTO, int>, ICustomerAppService
    {
        public CustomerAppService(ICustomerService appService, IMapper mapper) : base(appService, mapper) { }
    }
}