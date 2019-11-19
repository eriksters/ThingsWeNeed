namespace TwnData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Threading.Tasks;

    public class TwnContext : DbContext
    {
        // Your context has been configured to use a 'DataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ThingsWeNeed.Models.DataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModel' 
        // connection string in the application configuration file.
        public TwnContext()
            : base("name=TwnContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<AppUser> Users { get; set; }
        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }
        public virtual DbSet<Thing> Things { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder) {
            builder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        
    }
    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}