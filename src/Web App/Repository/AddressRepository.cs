using Microsoft.EntityFrameworkCore;
using Web_App.Data;
using Web_App.Interfaces;
using Web_App.Models;

namespace Web_App.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext database) : base(database)
        {
        }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await Database.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
        }
    }
}
