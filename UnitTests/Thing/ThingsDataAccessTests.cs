using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;

using Moq;

namespace ThingsWeNeed.UnitTests.Thing
{
    [TestClass]
    public class ThingsDataAccessTests
    {
        [TestMethod]
        public void Get()
        {
            //  Arrange
            ThingDaLogic logic = new ThingDaLogic(new TwnContext());

            //  Act
            var thingDto1 = logic.GetById(1);
            var thingDto2 = logic.GetById(2);

            //  Assert
            

        }

        [TestMethod]
        public void GetCollection()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Create()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Update()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
