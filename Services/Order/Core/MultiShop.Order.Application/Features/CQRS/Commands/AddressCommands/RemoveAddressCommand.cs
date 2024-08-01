namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public RemoveAddressCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
