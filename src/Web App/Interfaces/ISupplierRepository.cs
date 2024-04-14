using Microsoft.EntityFrameworkCore.Query;
using Web_App.Models;
using Web_App.ViewModels;

namespace Web_App.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid id);
        Task<Supplier> GetSupplierProductsAddress(Guid id);
    }
}
