using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {
        public string SenderCustomerName { get; set; }
        public string ReceiverCustomerName { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyID { get; set; }
    }
}
