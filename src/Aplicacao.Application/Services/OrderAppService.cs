using Aplicacao.Application.DTOs;
using Aplicacao.Application.Interfaces;
using Aplicacao.Domain.Interfaces.Services;
using Aplicacao.Domain.Model;
using AutoMapper;

namespace Aplicacao.Application.Services
{
    public class OrderAppService : BaseAppService<Order, OrderDTO, int>, IOrderAppService
    {
        public OrderAppService(IOrderService appService, IMapper mapper) : base(appService, mapper) { }
    }
}