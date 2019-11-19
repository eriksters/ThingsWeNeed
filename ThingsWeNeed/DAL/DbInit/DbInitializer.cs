using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL.DbInit
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseAlways<TwnContext>
    {
        protected override void Seed(TwnContext context)
        {
            ICollection<AppUser> Users = new List<AppUser> {
                new AppUser { Email = "eriksters@gmail.com",    Username = "eriksters", FName = "Eriks", LName = "Petersons", PhoneNumber = "81917581"},
                new AppUser { Email = "kristjonas@inbox.lt",    Username = "bigK", FName = "Kristjonas"},
                new AppUser { Email = "tfaludi@gmail.com",      Username = "Taamaaaas", FName = "Tamas", LName = "Faludi"},
                new AppUser { Email = "krissyboi@hotmail.com",  Username = "smallK", FName = "Krzisciek"},
                new AppUser { Email = "baduraAdam@gmail.com",   Username = "TheOneWithTheCabbage", FName = "Adam", LName = "Badura" },
                new AppUser { Email = "bi.amza@gmail.com",      Username = "bAmza", FName = "Bianca", LName = "Amza"},
                new AppUser { Email = "BlackKnight@gmail.com",  Username = "TheBlackKnight", FName = "Sivin" }
            };
            foreach (AppUser user in Users) 
                context.Users.Add(user);
            context.SaveChanges();

            ICollection<Household> Households = new List<Household> {
                new Household { Name = "Home", Address = "Rostrupsvej 7"},
                new Household { Name = "Crazyhouse", Address = "Rostrupsvej 2"}
            };
            foreach (Household household in Households)
                context.Households.Add(household);
            context.SaveChanges();

            ICollection<Thing> Things = new List<Thing> {
                new Thing { Name = "Toilet paper", DefaultPrice = 10, Needed = true, HouseholdId = 1 },
                new Thing { Name = "Skittles", DefaultPrice = 30, HouseholdId = 1},
                new Thing { Name = "Bread", DefaultPrice = 20, HouseholdId = 1},
                new Thing { Name = "Toilet paper", Needed = true, HouseholdId = 2},
                new Thing { Name = "Twix", Needed = true, HouseholdId = 2}
            };
            foreach (Thing thing in Things)
                context.Things.Add(thing);
            context.SaveChanges();

            ICollection<Wish> Wishes = new List<Wish> {
                new Wish { Name = "Carrots", ExtraPay = 5, MaxPrice = 30, MadeByUserId = 1, MadeOn = DateTime.Parse("19/10/2019"),
                    GrantedByUserId = 2, BoughtOn = DateTime.Parse("20/10/2019"), Status = Status.BoughtNotPaid },
                new Wish { Name = "Snickers", MaxPrice = 10, ExtraPay = 0, MadeByUserId = 2, MadeOn = DateTime.Now },
                new Wish { Name = "Potato", MaxPrice = 69, ExtraPay = 20, MadeByUserId = 2, MadeOn = DateTime.Parse("03/10/1999"),
                    GrantedByUserId = 1, BoughtOn = DateTime.Now, Status = Status.BoughtPaid },
                new Wish { Name = "Pizza", MaxPrice = 150, ExtraPay = 30, MadeByUserId = 5, MadeOn = DateTime.Parse("19/11/2019")},
                new Wish { Name = "Tomato", MaxPrice = 10, ExtraPay = 1, MadeByUserId = 3, MadeOn = DateTime.Parse("11/11/2019"),
                    Status = Status.Cancelled }
            };
            foreach (Wish wish in Wishes)
                context.Wishes.Add(wish);
            context.SaveChanges();

            ICollection<Purchase> Purchases = new List<Purchase> {
                new Purchase { Paid = 19, ThingId = 1, MadeById = 1, HouseholdId = 1, MadeOn = DateTime.Now },
                new Purchase { Paid = 29, ThingId = 2, MadeById = 2, HouseholdId = 1, MadeOn = DateTime.Parse("1/11/2019") },
                new Purchase { Paid = 20, ThingId = 3, MadeById = 1, HouseholdId = 1, MadeOn = DateTime.Parse("2/11/2019") }
            };
            foreach (Purchase purchase in Purchases)
                context.Purchases.Add(purchase);
            context.SaveChanges();
        }
    }
}