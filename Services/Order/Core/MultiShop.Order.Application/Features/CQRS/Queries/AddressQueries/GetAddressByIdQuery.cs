namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public GetAddressByIdQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
