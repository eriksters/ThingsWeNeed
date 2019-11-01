using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;

namespace TestConsoleApp {
    class Program {
        static void Main(string[] args) {
            //AppUser user = new AppUser() {
            //    Email = "eriksters@gmail.com",
            //    FName = "Eriks",
            //    LName = "Petersons",
            //    UserId = 12,
            //    PhoneNumber = "81917581",
            //};

            //ModelContainer mc = new ModelContainer();
            //mc.AppUsers.Add(user);



            //Household hh = new Household() {
            //    Address = "Rostrupsvej 7",
            //    Name = "Crackhouse",
            //};

            //Thing t = new Thing() {
            //    Name = "Toilet Paper",
            //    Needed = false,
            //};

            //hh.Things.Add(t);

            //mc.Households.Add(hh);
            //mc.SaveChanges();
            //Console.WriteLine("Hellow World");
            //Console.Read();

            //ModelContainer mc = new ModelContainer();
            //AppUser user = mc.AppUsers.Find(1);
            //Household hh = mc.Households.Find(1);
            //hh.AppUsers.Remove(user);
            //mc.SaveChanges();

            //Console.WriteLine(user.Email);

            //addUser("Erisk", "ASdasd", "ers@gs.ss", "81917581");

            //createHousehold("CrazzyHouse", "Rostrupsvej 1");
            //createHousehold("Crackhouse", "Rostrupsvej 7");

            addThingToHousehold(1, "Dorritos");
            addThingToHousehold(1, "Bread");
            printHouseholds();
            Console.Read();
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
