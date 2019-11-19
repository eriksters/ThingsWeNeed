using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwnData;
using ThingsWeNeed.Controllers;
using ThingsWeNeed.Models.Binders;

namespace Tests
{
    [TestClass]
    public class NeedsTests
    {
        private TwnContext context;
        private NeedsController nCtr;

        [TestInitialize]
        public void TestInit() 
        {
            context = new TwnContext();
            context.Database.Delete();
            context.Database.Create();
            context.Database.Initialize(true);

            nCtr = new NeedsController(context);
        }

        [TestMethod]
        public void Test_CreateNeed_ValidData()
        {

        }

        [TestMethod]
        public void Test_CreateNeed_InvalidData()
        {

        }

        [TestMethod]
        public void Test_CreatePurchase_ValidData() 
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

            //  Act
            nCtr.Purchase(data);

            //  Assert
            Assert.IsTrue(context.Things.Find(thingId1).Needed);
            Assert.IsTrue(context.Things.Find(thingId2).Needed);

            Assert.IsTrue(context.Users.Find(1).Purchases.Count == 4);

        }

        [TestMethod]
        public void Test_CreatePurchase_InvalidData()
        {
            int thingId1 = 3;
            int thingId2 = 4;

            //  Assign
            CreateNeedData thing1 = new CreateNeedData
            {
                ThingId = thingId1
            };
            CreateNeedData thing2 = new CreateNeedData
            {
                ThingId = thingId2
            };
            CreateNeedData[] data = { thing1, thing2 };

            //  Act
            nCtr.Purchase(data);

            //  Assert
            Assert.IsTrue(!context.Things.Find(thingId1).Needed);
            Assert.IsTrue(!context.Things.Find(thingId2).Needed);

            //Assert.IsTrue(context.Users.Find(1).Purchases.Count == 2);
        }
    }
}
