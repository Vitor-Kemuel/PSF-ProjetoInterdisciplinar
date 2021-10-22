namespace ProjectInter.Repositories
{
    public interface IAddressRepository
    {
        void CreateAddressOfCustomer(int idCustomer);
        void GetSingleAddressOfCustomer(int idCustomer);
         void GetAllAddressOfCustomer(int idCustomers);
         void UptadeAddressOfCustomer(int idCustomers, int idAddress);
         void DeleteOfAddress(int idAddress);
    }
}