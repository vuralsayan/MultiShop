using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
    {
       private readonly IOrderingRepository _orderingRepository;
        private readonly IMapper _mapper;

        public GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository, IMapper mapper)
        {
            _orderingRepository = orderingRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orderings = await _orderingRepository.GetOrderingsByUserIdAsync(request.ID);
            var orderingsResult = _mapper.Map<List<GetOrderingByUserIdQueryResult>>(orderings);
            return orderingsResult;
        }
    }
}
