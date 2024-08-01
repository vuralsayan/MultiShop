using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public int ID { get; set; }

        public RemoveOrderDetailCommand(int id)
        {
            ID = id;
        }
    }
}
