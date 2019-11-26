using System.Data.Entity;

using ThingsWeNeed.Data.Household;
using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Thing;

namespace ThingsWeNeed.Data.Core
{
    public class TwnContext : DbContext
    {
        //  Singleton pattern
        private static TwnContext instance;

        public static TwnContext Instance {
            get {
                if (instance == null)
                    instance = new TwnContext();
                return instance;
            }
            private set {
                instance = value;
            }
        }

        public DbSet<ThingEntity> Things { get; private set; }

        public DbSet<HouseholdEntity> Households { get; private set; }

        public DbSet<UserEntity> Users { get; private set; } 
    }
}
