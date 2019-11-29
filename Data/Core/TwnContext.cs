using System.Data.Entity;

using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Thing;

namespace ThingsWeNeed.Data.Core
{
    public class TwnContext : DbContext
    {
        public TwnContext() : base()
        { }
        
        public DbSet<ThingEntity> Things { get; set; }

        public DbSet<HouseholdEntity> Households { get; set; }

        public DbSet<UserEntity> Users { get; set; } 
    }
}
