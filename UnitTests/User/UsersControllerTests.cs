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
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.UnitTests.User
{
    [TestClass]
    public class UsersControllerTests
    {
        public TwnContext DatabaseContext { get; private set; }

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
            // Arrange
            var UserList = getTestUser();
            int householdId = 6;
            try
            {
                var controller = TestData.GetInjectedController2();

                // Act 
                var result = (OkNegotiatedContentResult<UserDto[]>)controller.GetCollection(householdId);

                // Assert
                Assert.IsTrue(result.Content.Length > 0 ? true : false);
            }
            finally
            {
                cleanup(UserList.UserId);
            }
        }

        [TestMethod]
        public void Update_Ok()
        {
            // Arrange 
            var user = getTestUser();
            // user to update
            int userId = user.UserId;
            // household with updated data
            UserEntity updatedUser = new UserEntity();
            // data for update
            string FName = "Apolonijas";
            string LName = "Mockutes";
            string PhoneNumber = "+698742541";
            string Email = "wefdf@gm.lt";
            string Username = "yeet";
            // preparing an updated entity
            updatedUser.UserId = userId;
            updatedUser.FName = FName;
            updatedUser.LName = LName;
            updatedUser.PhoneNumber = PhoneNumber;
            updatedUser.Email = Email;
            updatedUser.Username = Username;

            try
            {
                var controller = TestData.GetInjectedController2();

                // Act 
                var result = (OkNegotiatedContentResult<UserDto>)controller.Update(userId, updatedUser);

                // Assert
                if (result.Content.FName.Equals(FName) && result.Content.LName.Equals(LName) &&
                    result.Content.PhoneNumber.Equals(PhoneNumber) && result.Content.Username.Equals(Username) &&
                    result.Content.Email.Equals(Email))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            finally
            {
                cleanup(user.UserId);
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
        public void Delete_Ok()
        {
            // Arrange
            var user = getTestUser();
            int userId = user.UserId;

            try
            {
                var controller = TestData.GetInjectedController2();

                // Act
                var result = (OkNegotiatedContentResult<bool>)controller.Delete(userId);

                // Assert
                Assert.IsTrue(result.Content);
            }
            finally
            {
                cleanup(userId);
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

        public UserDto buildDto(UserEntity entity)
        {
            if (entity != null)
            {
                UserDto dto = new UserDto()
                {
                    UserId = entity.UserId,
                    FName = entity.FName,
                    LName = entity.LName,
                    PhoneNumber = entity.PhoneNumber,
                    Username = entity.Username,
                    Email = entity.Email
                };
                return dto;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }


    }
}
