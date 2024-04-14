using Web_App.Models;

namespace Web_App.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductBySupplier(Guid supplierId);
        Task<IEnumerable<Product>> GetProductSupplier();
        Task<Product> GetProductSupplier(Guid id);
    }
}
