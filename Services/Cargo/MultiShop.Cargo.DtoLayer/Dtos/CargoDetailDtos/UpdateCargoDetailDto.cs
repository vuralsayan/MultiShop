using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailID { get; set; }
        public string SenderCustomerName { get; set; }
        public string ReceiverCustomerName { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyID { get; set; }
    }
}
