using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
    {
        Task<CargoCustomer> GetCargoCustomerByUserCustomerID(string userCustomerID);
    }
}
