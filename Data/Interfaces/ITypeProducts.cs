namespace ProjectInter.Data.Interfaces
{
    public interface IdTypeProducts
    {
        void Create();

        void GetSingleTypeProducts(int IdTypeProducts);

        void GetAllTypeProducts();

        void UpdateTypeProducts(int IdTypeProducts);
    }
}