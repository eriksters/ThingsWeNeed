using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Design;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
/// A code first entity framework Data Context
/// </summary>
namespace TwnData
{
    public class TwnContext : DbContext
    {
        public TwnContext () {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TwnContext>());
            //Database.SetInitializer<TwnContext>(new DropCreateDatabaseAlways<TwnContext>());
        }

        public DbSet<ThingEntity> Things { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<HouseholdEntity> Households { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<WishEntity> Wishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}