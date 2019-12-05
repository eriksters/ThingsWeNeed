using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using ThingsWeNeed.Data.User;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;
using ThingsWeNeed.Service.Controllers.User;

using Moq;
using ThingsWeNeed.Controllers.User;
using System.Web.Http.Results;

using ThingsWeNeed.UnitTests;
using System.Web.Http;
using System.Diagnostics;
using ThingsWeNeed.Data.Household;

namespace ThingsWeNeed.UnitTests.User
{
    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        public void Get_Ok()
        {

            //  Arrange
            var user = getTestUser();
            try
            {
                var controller = TestData.GetInjectedController2();

                //  Act
                var result = (OkNegotiatedContentResult<UserDto>)controller.Get(user.UserId);

                //  Assert
                Assert.IsTrue(result.Content.LName == user.LName);

                //  Cleanup
            }
            finally
            {
                cleanup(user.UserId);
            }
        }

        [TestMethod]
        public void GetCollection_Ok()
        {
            //  Arrange
            var user1 = getTestUser();
            var user2 = getTestUser();
            var controller = TestData.GetInjectedController();

            try
            {
                //  Act
                var result = (OkNegotiatedContentResult<ICollection<UserDto>>)controller.GetCollection();

                //  Assert
                bool found1 = false;
                bool found2 = false;
                foreach (var t in result.Content)
                {
                    if (t.UserId == user1.UserId)
                    {
                        found1 = true;
                    }
                    else if (t.UserId == user2.UserId)
                    {
                        found2 = true;
                    }
                }
                Assert.IsTrue(found1);
                Assert.IsTrue(found2);

                //  Cleanup
            }
            finally
            {

                cleanup(user1.UserId);
                cleanup(user2.UserId);
            }
        }

        [TestMethod]
        public void Create_Ok()
        {

            //  Arrange
            var dto = TestData.TestUser1;
            var userEn = getTestUser();
            //string name = "Toothpaste";
            //int householdId = 96;
            //bool show = false;
            //bool needed = true;
            //double defaultPrice = 15;

            UserDaLogic logic = new UserDaLogic();
            UserDto userDto = null;


            //  Act
            try
            {
                userDto = logic.Create(dto.FName, dto.LName, dto.PhoneNumber, dto.Username, dto.Email);
                //thingDto = logic.GetById(213);

                var assertUser = logic.DatabaseContext.Users.Find(userDto.UserId);

                Assert.IsNotNull(assertUser);

                //Assert.IsTrue(thingDto.Name.Equals(name));
                //Assert.IsTrue(thingDto.HouseholdId == householdId);
                //Assert.IsFalse(thingDto.Show);
                //Assert.IsTrue(thingDto.Needed);
                //Assert.IsTrue(thingDto.DefaultPrice == defaultPrice);
            }
            //  Cleanup
            finally
            {
                try
                {
                    cleanup(userDto.UserId);
                    cleanup(userEn.UserId);
                }
                catch { }
            }

        }

        [TestMethod]
        public void Update_Ok()
        {
            //  Arrange

            var user = getTestUser();
            int id = user.UserId;
            try
            {
                OkNegotiatedContentResult<UserDto> result;

                //  Act
                using (var controller = TestData.GetInjectedController2())
                {
                    result = (OkNegotiatedContentResult<UserDto>)controller.Update(id, TestData.TestUser2);
                }

                //  Assert
                Assert.IsTrue(result.Content.LName == user.LName);
            }
            finally
            {
                cleanup(user.UserId);
            }
        }



        [TestMethod]
        public void Delete_Ok()
        {

            //  Arrange

            var user = getTestUser();
            int id = user.UserId;
            try
            {
                var controller = TestData.GetInjectedController2();

                //  Act
                var result = (OkNegotiatedContentResult<UserDto>)controller.Delete(id);

                //  Assert
                Assert.IsTrue(result.Content.LName == user.LName);

                //  Cleanup
            }
            finally
            {
                //cleanup(id);
            }
        }




        public UserEntity getTestUser()
        {

            TwnContext context = new TwnContext();

            var User = new UserEntity()
            {
                UserId = 10,
                FName = "Kristijonas",
                LName = "Mockus",
                PhoneNumber = "+4525457898",
                Username = "Pou",
                Email = "krkrk@gmail.com"
            };

            var userEntity = context.Users.Add(User);
            using (context)
            {
                context.SaveChanges();
            }
            return userEntity;
        }



        private void cleanup(int id)
        {
            UserEntity User;
            using (TwnContext context = new TwnContext())
            {
                User = context.Users.Find(id);
                context.Users.Remove(User);
                context.SaveChanges();
            }
        }


    }
}
