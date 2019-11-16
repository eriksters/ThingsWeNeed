using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;

namespace TestConsoleApp {
    class Program {
        static void Main(string[] args) {
            //TestDataFactory tdf = new TestDataFactory();
            //using (ModelContainer mc = new ModelContainer())
            //{
            //    tdf.createTestData(mc);
            //}

            RepositoryTest rt = new RepositoryTest();
            rt.Test();

            Console.Read();
        }

        private static bool sqlQueries()
        {
            using (ModelContainer mc = new ModelContainer())
            {
                Purchase p1 = mc.Purchases.Find(1);
                Purchase p2 = mc.Purchases.Find(2);

                List<Purchase> p = mc.Purchases.ToList();
                Purchase p3 = mc.Purchases.Find(1);
                Purchase p4 = mc.Purchases.Find(3);

                
            }

            return true;
        }

        private static bool addUser(String fName, string lName, string email, string phoneNumber) {
            AppUser newUser = new AppUser() {
                FName = fName,
                LName = lName,
                Email = email,
                PhoneNumber = phoneNumber,
                UserId = 1
            };

            using (ModelContainer mc = new ModelContainer()) {
                mc.AppUsers.Add(newUser);
                mc.SaveChanges();
            }
            return true;
        }

        private static bool addThingToHousehold(int householdId, string thingName)
        {
            ModelContainer mc = new ModelContainer();
            Household hh = mc.Households.Find(householdId);
            Thing newThing = new Thing()
            {
                Name = thingName,
                Needed = true
            };

            hh.Things.Add(newThing);
            mc.SaveChanges();

            return true;
        }

        private static bool createHousehold(string name, string address)
        {
            ModelContainer mc = new ModelContainer();
            Household hh = new Household()
            {
                Address = address,
                Name = name,
            };
            mc.Households.Add(hh);
            mc.SaveChanges();

            return true;
        }

        private static bool printHouseholds()
        {
            ModelContainer mc = new ModelContainer();
            foreach (Household hh in mc.Households)
            {
                Console.WriteLine("Name:" + hh.Name);
                Console.WriteLine("Address:" + hh.Address);
                Console.WriteLine("ID:" + hh.HouseholdId);
                Console.WriteLine("Things:" + hh.Things.Count);
            }

            return true;
        }
    }

    
}
