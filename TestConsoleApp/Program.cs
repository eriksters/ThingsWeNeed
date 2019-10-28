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

            addUser("Erisk", "ASdasd", "ers@gs.ss", "81917581");


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
    }

    
}
