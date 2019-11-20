using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwnData;
using ThingsWeNeed.Controllers;
using ThingsWeNeed.Models.Binders;

namespace Tests
{
    [TestClass]
    public class NeedsTests
    {

        public NeedsTests()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            TwnContext context = new TwnContext();
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));

            if (context.Database.Exists())
                context.Database.Delete();

            context.Database.Create();
            context.Database.Initialize(true);
            context.Dispose();
        }

        [TestMethod]
        public void Test_CreateNeed()
        {

        }

        [TestMethod]
        public void Test_CreatePurchase() 
        {
            int thingId1 = 1;
            int thingId2 = 2;

            //  Assign
            CreateNeedData thing1 = new CreateNeedData {
                ThingId = thingId1,
                ThingPrice = 20
            };
            CreateNeedData thing2 = new CreateNeedData
            {
                ThingId = thingId2,
                ThingPrice = 30
            };
            CreateNeedData[] data = { thing1, thing2 };

            TwnContext context = new TwnContext();
            NeedsController nCtr = new NeedsController(context);

            //  Act
            nCtr.Purchase(data);

            //  Assert
            context = new TwnContext();
            Assert.IsTrue(!context.Things.Find(thingId1).Needed);
            Assert.IsTrue(!context.Things.Find(thingId2).Needed);

            Assert.IsTrue(context.Users.Find(1).Purchases.Count == 4);

        }
    }
}
