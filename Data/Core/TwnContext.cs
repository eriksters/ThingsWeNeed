using System.Data.Entity;

using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.Migrations;

namespace ThingsWeNeed.Data.Core
{
    public class TwnContext : DbContext
    {
        public TwnContext() : base()
        {
            Database.SetInitializer<TwnContext>(new CreateDatabaseIfNotExists<TwnContext>());
        }
        
        public DbSet<ThingEntity> Things { get; set; }

        public DbSet<HouseholdEntity> Households { get; set; }

        public DbSet<UserEntity> Users { get; set; } 
    }
}
