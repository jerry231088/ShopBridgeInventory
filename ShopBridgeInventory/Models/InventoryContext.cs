using Microsoft.EntityFrameworkCore;

namespace ShopBridgeInventory.Models
{
    //EF Code First Approach
    public class InventoryContext: DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options): base(options)
        {

        }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
