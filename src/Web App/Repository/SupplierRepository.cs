using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Web_App.Data;
using Web_App.Interfaces;
using Web_App.Models;
using Web_App.ViewModels;

namespace Web_App.Repository
{
    public class SupplierRepository(ApplicationDbContext context) : Repository<Supplier>(context), ISupplierRepository
    {
        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await Database.Suppliers.AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Supplier> GetSupplierProductsAddress(Guid id)
        {
            return await Database.Suppliers.AsNoTracking()
                .Include(a => a.Products)
                .Include(a => a.Address)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
