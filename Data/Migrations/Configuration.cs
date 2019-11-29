namespace ThingsWeNeed.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ThingsWeNeed.Data.Thing;
    using ThingsWeNeed.Data.User;
    using ThingsWeNeed.Data.Household;
    using ThingsWeNeed.Data.Core;
    using ThingsWeNeed.Shared;

    internal sealed class Configuration : DbMigrationsConfiguration<TwnContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TwnContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            HouseholdEntity bestHouse = new HouseholdEntity()
            {
                Address = new AddressDto()
                {
                    Address1 = "Rostrupsvej 7, 2",
                    City = "Aalborg",
                    Country = "DK",
                    PostCode = "9000"
                },
                Name = "Best house"
            };

            HouseholdEntity crazyHouse = new HouseholdEntity()
            {
                Address = new AddressDto()
                {
                    Address1 = "Rostrupsvej 2",
                    City = "Aalborg",
                    Country = "DK",
                    PostCode = "9000"
                },
                Name = "Crazyhouse",

            };

            context.Households.AddOrUpdate(bestHouse);
            context.Households.AddOrUpdate(crazyHouse);

            UserEntity eriks = new UserEntity() {
                Username = "eriksters",
                FName = "Eriks",
                LName = "Petersons",
                PhoneNumber = "81917581",
                PenisSize = 20,
                Email = "eriksters@gmail.com"
            };
            eriks.Households.Add(bestHouse);

            UserEntity tomi = new UserEntity()
            {
                Username = "TomiBoi",
                FName = "Tamas",
                LName = "Faludi",
                PhoneNumber = "21387812",
                PenisSize = 15,
                Email = "falude@gmail.com"
            };
            tomi.Households.Add(bestHouse);

            UserEntity adam = new UserEntity()
            {
                Username = "PointFivePercentJew",
                FName = "Adam",
                LName = "Badura",
                PhoneNumber = "93423423",
                PenisSize = 20,
                Email = "MrBadura@gmail.com"
            };
            adam.Households.Add(bestHouse);

            UserEntity kristjonas = new UserEntity()
            {
                Username = "Kristjonas",
                FName = "Kristjonas",
                LName = "Something",
                PhoneNumber = "19283912",
                PenisSize = 20,
                Email = "BigK@gmail.com"
            };
            kristjonas.Households.Add(bestHouse);

            UserEntity krzcizsciek = new UserEntity()
            {
                Username = "KBoy",
                FName = "krzcizsciek",
                LName = "Idontevenknow",
                PhoneNumber = "18247812",
                PenisSize = 1,
                Email = "kkkBoy@hotmail.com"
            };
            krzcizsciek.Households.Add(bestHouse);

            UserEntity bianca = new UserEntity()
            {
                Username = "BAmza",
                Email = "amzaPhotography@gmail.com",
                FName = "Bianca",
                LName = "Amza",
                PenisSize = 0,
                PhoneNumber = "90901001"
            };
            bianca.Households.Add(bestHouse);
            bianca.Households.Add(crazyHouse);

            context.Users.AddOrUpdate(eriks);
            context.Users.AddOrUpdate(tomi);
            context.Users.AddOrUpdate(adam);
            context.Users.AddOrUpdate(kristjonas);
            context.Users.AddOrUpdate(krzcizsciek);
            context.SaveChanges();

            ThingEntity tp = new ThingEntity() {
                Name = "Toilet paper",
                Show = true,
                Needed = true,
                DefaultPrice = 20,
                Household = bestHouse
            };

            ThingEntity bread = new ThingEntity()
            {
                Name = "Bread",
                Show = true,
                Needed = false,
                DefaultPrice = 8,
                Household = bestHouse
            };

            ThingEntity milk = new ThingEntity()
            {
                Name = "Milk",
                Show = true,
                Needed = true,
                DefaultPrice = 10,
                Household = bestHouse
            };

            ThingEntity halloweenDrinks = new ThingEntity()
            {
                Name = "Halloween drinks",
                Needed = false,
                Show = false,
                Household = bestHouse,
                DefaultPrice = 49
            };

            context.Things.AddOrUpdate(tp);
            context.Things.AddOrUpdate(bread);
            context.Things.AddOrUpdate(milk);
            context.Things.AddOrUpdate(halloweenDrinks);
        }
    }
}
