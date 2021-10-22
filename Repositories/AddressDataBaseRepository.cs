namespace ProjectInter.Repositories
{
    public class AddressDataBaseRepository : BDContext, IAddressRepository
    {
        public void CreateAddressOfCustomer(int idCudtomer)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteOfAddress(int idAddress)
        {
            throw new System.NotImplementedException();
        }

        public void GetAllAddressOfCustomer(int idCustomers)
        {
            throw new System.NotImplementedException();
        }

        public void UptadeAddressOfCustomer(int idCustomers, int idAddress)
        {
            throw new System.NotImplementedException();
        }

        void IAddressRepository.GetSingleAddressOfCustomer(int idCustomer)
        {
            throw new System.NotImplementedException();
        }
    }
}