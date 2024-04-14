using Microsoft.EntityFrameworkCore;
using Web_App.Data;
using Web_App.Interfaces;
using Web_App.Models;

namespace Web_App.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductBySupplier(Guid supplierId)
        {
            return await Search(p => p.SupplierId == supplierId);
        }

        public async Task<IEnumerable<Product>> GetProductSupplier()
        {
            return await Database.Products.AsNoTracking().Include(s => s.Supplier).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await Database.Products.AsNoTracking().Include(s => s.Supplier).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
