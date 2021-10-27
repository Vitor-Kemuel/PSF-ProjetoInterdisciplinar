namespace ProjectInter.Data.Interfaces
{
    public interface IProductsRepository
    {
        void Create();

        void GetProducts(int IdProduct);

        void GetAllProducts();

        void UpdateProdutc(int IdProduct);
    }
}