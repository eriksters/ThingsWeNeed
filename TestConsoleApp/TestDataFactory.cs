using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ThingsWeNeed.Models;

namespace TestConsoleApp {
    class TestDataFactory {

        public void createTestData(ModelContainer mc)
        {

            //  Create things for first household
            Thing thing1 = new Thing()
            {
                Name = "Toilet Paper",
                DefaultPrice = "19",
                Needed = false,
            };
            Thing thing2 = new Thing()
            {
                Name = "Bread",
                DefaultPrice = "10",
                Needed = false,
            };
            Thing thing3 = new Thing()
            {
                Name = "Dish soap",
                DefaultPrice = "29",
                Needed = false,
            };
            
            //  Create users
            AppUser user1 = new AppUser() {
                Email = "eriksters@gmail.com",
                FName = "Eriks",
                LName = "Petersons",
                PhoneNumber = "81917581",
            };
            AppUser user2 = new AppUser() {
                Email = "Faludi@hotmail.com",
                FName = "Tamas",
                LName = "Faludi",
                PhoneNumber = "90901001",
            };

            //  Create households
            Household household1 = new Household() {
                Address = "Sofiendalsvej 60",
                Name = "Safiendalsvej house",
                Things = { thing1, thing2, thing3 },
                AppUsers = { user1, user2 }
            };
            Household household2 = new Household() {
                Address = "Reberbansgade 69",
                Name = "Office",
                Things =
                {
                    new Thing()
                    {       
                        Name = "Staples",
                        DefaultPrice = "29",
                        Needed = true
                    }
                },
                AppUsers = { user1 }
            };


            Purchase purchase1 = new Purchase()
            {
                MadeOn = DateTime.Now,
                Paid = 29,
            };
            user1.Purchases.Add(purchase1);
            household1.Purchases.Add(purchase1);
            thing1.Purchases.Add(purchase1);

            mc.Households.Add(household1);
            mc.Households.Add(household2);
            mc.SaveChanges();

            Console.WriteLine("Created user [{0} {1}] with id [{2}]", user1.FName, user1.LName, user1.UserId);
            Console.WriteLine("Created user [{0} {1}] with id [{2}]", user2.FName, user2.LName, user2.UserId);
            Console.WriteLine("Created household [{0}] with id [{1}]", household1.Name, household1.HouseholdId);
            Console.WriteLine("Created purchase with id [{0}], thing id [{1}], user id [{2}], household id [{3}]",
                purchase1.PurchaseId, purchase1.Thing.ThingId, purchase1.AppUser.UserId, purchase1.Household.HouseholdId);
        }
    }
}
