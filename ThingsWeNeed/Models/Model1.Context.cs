﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThingsWeNeed.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ModelContainer : DbContext
    {
        public ModelContainer()
            : base("name=ModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Thing> Things { get; set; }
        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Wish> Wishes { get; set; }
    
        public virtual ObjectResult<Purchase> ThingLastPurchase(Nullable<int> thingId)
        {
            var thingIdParameter = thingId.HasValue ?
                new ObjectParameter("thingId", thingId) :
                new ObjectParameter("thingId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Purchase>("ThingLastPurchase", thingIdParameter);
        }
    
        public virtual ObjectResult<Purchase> ThingLastPurchase(Nullable<int> thingId, MergeOption mergeOption)
        {
            var thingIdParameter = thingId.HasValue ?
                new ObjectParameter("thingId", thingId) :
                new ObjectParameter("thingId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Purchase>("ThingLastPurchase", mergeOption, thingIdParameter);
        }
    }
}
