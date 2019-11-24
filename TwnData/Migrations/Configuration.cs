using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TwnData;

namespace TwnData.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TwnData.TwnContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TwnContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data

            UserEntity eriks = new UserEntity { PenisSize = 10, Email = "eriksters@gmail.com", Username = "eriksters", FName = "Eriks", LName = "Petersons", PhoneNumber = "81917581" };
            UserEntity kristjonas = new UserEntity { Email = "kristjonas@inbox.lt", Username = "bigK", FName = "Kristjonas", PenisSize = 6 };
            UserEntity tomi = new UserEntity { Email = "tfaludi@gmail.com", Username = "Taamaaaas", FName = "Tamas", LName = "Faludi" , PenisSize = 3};
            UserEntity kris = new UserEntity { Email = "krissyboi@hotmail.com", Username = "smallK", FName = "Krzisciek", PenisSize = 2 };
            UserEntity adam = new UserEntity { Email = "baduraAdam@gmail.com", Username = "TheOneWithTheCabbage", FName = "Adam", LName = "Badura", PenisSize = 6 };
            UserEntity bianca = new UserEntity { Email = "bi.amza@gmail.com", Username = "bAmza", FName = "Bianca", LName = "Amza", PenisSize = 0 };
            UserEntity sivin = new UserEntity { Email = "BlackKnight@gmail.com", Username = "TheBlackKnight", FName = "Sivin", PenisSize = 5 };

            context.Users.AddOrUpdate(eriks);
            context.Users.AddOrUpdate(kristjonas);
            context.Users.AddOrUpdate(tomi);
            context.Users.AddOrUpdate(kris);
            context.Users.AddOrUpdate(adam);
            context.Users.AddOrUpdate(bianca);
            context.Users.AddOrUpdate(sivin);
            context.SaveChanges();

            HouseholdEntity home = new HouseholdEntity
            {
                Name = "Home",
                Address = new Address
                {
                    Address1 = "Rostrupsvej 7, 2",
                    City = "Aalborg",
                    PostCode = "9000",
                    Country = "DK"
                }
            };
            HouseholdEntity crazyHouse = new HouseholdEntity
            {
                Name = "Crazyhouse",
                Address = new Address
                {
                    Address1 = "Rostrupsvej 2",
                    City = "Aalborg",
                    PostCode = "9000",
                    Country = "DK"
                }
            };

            home.Users.Add(eriks);
            home.Users.Add(kristjonas);
            home.Users.Add(tomi);
            home.Users.Add(kris);
            home.Users.Add(adam);
            home.Users.Add(bianca);
            crazyHouse.Users.Add(bianca);
            crazyHouse.Users.Add(sivin);

            context.Households.AddOrUpdate(home);
            context.Households.AddOrUpdate(crazyHouse);
            context.SaveChanges();

            ICollection<ThingEntity> Things = new List<ThingEntity> {
                new ThingEntity { Name = "Toilet paper", DefaultPrice = 10, HouseholdId = 1 },
                new ThingEntity { Name = "Skittles", DefaultPrice = 30, HouseholdId = 1},
                new ThingEntity { Name = "Bread", DefaultPrice = 20, Needed = true, HouseholdId = 1},
                new ThingEntity { Name = "Toilet paper", Needed = true, HouseholdId = 2},
                new ThingEntity { Name = "Twix", Needed = true, HouseholdId = 2}
            };
            foreach (ThingEntity thing in Things)
                context.Things.AddOrUpdate(thing);
            context.SaveChanges();

            ICollection<WishEntity> Wishes = new List<WishEntity> {
                new WishEntity { Name = "Carrots", ExtraPay = 5, MaxPrice = 30, MadeByUserId = 1, MadeOn = DateTime.Parse("19/10/2019"),
                    GrantedByUserId = 2, BoughtOn = DateTime.Parse("20/10/2019"), Status = WishStatus.BoughtNotPaid },
                new WishEntity { Name = "Snickers", MaxPrice = 10, ExtraPay = 0, MadeByUserId = 2, MadeOn = DateTime.Now },
                new WishEntity { Name = "Potato", MaxPrice = 69, ExtraPay = 20, MadeByUserId = 2, MadeOn = DateTime.Parse("03/10/1999"),
                    GrantedByUserId = 1, BoughtOn = DateTime.Now, Status = WishStatus.BoughtPaid },
                new WishEntity { Name = "Pizza", MaxPrice = 150, ExtraPay = 30, MadeByUserId = 5, MadeOn = DateTime.Parse("19/11/2019")},
                new WishEntity { Name = "Tomato", MaxPrice = 10, ExtraPay = 1, MadeByUserId = 3, MadeOn = DateTime.Parse("11/11/2019"),
                    Status = WishStatus.Cancelled }
            };
            foreach (WishEntity wish in Wishes)
                context.Wishes.AddOrUpdate(wish);
            context.SaveChanges();

            ICollection<PurchaseEntity> Purchases = new List<PurchaseEntity> {
                new PurchaseEntity { Paid = 19, ThingId = 1, MadeById = 1, HouseholdId = 1, MadeOn = DateTime.Now },
                new PurchaseEntity { Paid = 29, ThingId = 2, MadeById = 2, HouseholdId = 1, MadeOn = DateTime.Parse("1/11/2019") },
                new PurchaseEntity { Paid = 20, ThingId = 3, MadeById = 1, HouseholdId = 1, MadeOn = DateTime.Parse("2/11/2019") }
            };
            foreach (PurchaseEntity purchase in Purchases)
                context.Purchases.AddOrUpdate(purchase);
            context.SaveChanges();
        }
    }
}
