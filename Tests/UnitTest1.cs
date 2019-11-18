using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Repositories;
using ThingsWeNeed.DAL;
using ThingsWeNeed.Models;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckDatabase()
        {
            IUnitOfWork uWork = new TestUnitOfWork();

            Assert.IsTrue(uWork.ThingRepository.GetById(1) != null);
            Assert.IsTrue(uWork.WishRepository.GetById(1) != null);
            Assert.IsTrue(uWork.PurchaseRepository.GetById(1) != null);
            Assert.IsTrue(uWork.UserRepository.GetById(1) != null);
            Assert.IsTrue(uWork.HouseholdRepository.GetById(1) != null);
        }
    }
}
