using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Data.Wish;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Shared;
<<<<<<< Updated upstream
using ThingsWeNeed.Service.Controllers.Wish;
=======
//using ThingsWeNeed.Service.Controllers.Wish;
>>>>>>> Stashed changes
using System.Web.Http.Results;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.UnitTests.Wish
{
<<<<<<< Updated upstream
   
=======
  /* 
>>>>>>> Stashed changes
    [TestClass]
    public class WishesControllerTests
    {
        [TestMethod]
        public void Get_Ok()
        {

            //  Arrange
            var wish = getTestWish();
            try
            {
                var controller = TestData.GetInjecteddController();

                //  Act
                var result = (OkNegotiatedContentResult<WishDto>)controller.Get(wish.WishId);

                //  Assert
                Assert.IsTrue(result.Content.MaxPrice == wish.MaxPrice);

                //  Cleanup
            }
            finally
            {
                cleanup(wish.WishId);
            }
        }

        [TestMethod]
        public void GetCollection_Ok()
        {
<<<<<<< Updated upstream
            //  Arrange
            var wish1 = getTestWish();
=======
            var wish1 = getTestWish();
            //  Arrange
>>>>>>> Stashed changes
            var wish2 = getTestWish();
            var controller = TestData.GetInjecteddController();

            try
            {
                //  Act
                var result = (OkNegotiatedContentResult<ICollection<WishDto>>)controller.GetCollection();

                //  Assert
                bool found1 = false;
                bool found2 = false;
                foreach (var t in result.Content)
                {
                    if (t.WishId == wish1.WishId)
                    {
                        found1 = true;
                    }
                    else if (t.WishId == wish2.WishId)
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

                cleanup(wish1.WishId);
                cleanup(wish2.WishId);
            }
        }

        public WishEntity getTestWish()
        {
            TwnContext context = new TwnContext();

            var user = context.Users.Add(new UserEntity()
            {  
               Email = "s.f@j.d",
                FName = "TestNameUser",
<<<<<<< Updated upstream
                Username = "skooter",
                PhoneNumber = "0944587369",
                LName = "larry",
                PenisSize = 123123f
=======
                PhoneNumber = "0944587369",
                LName = "larry",
                
               
>>>>>>> Stashed changes
            });
            
            double price = new Random().Next(0, 200);
            var wish = new WishEntity()
            {
                MaxPrice = price,
                ExtraPay = 7,
                GrantedOn = DateTime.Today,
<<<<<<< Updated upstream
                User = user,
                Name = "noose"
=======
                GrantedBy = user,
                Name = "noose",
               
>>>>>>> Stashed changes
            };

            var wishEntity = context.Wishes.Add(wish);
            context.Users.Add(user);
            using (context)
            {
                context.SaveChanges();
            }
            return wishEntity;
        }

        [TestMethod]
        public void Delete_Ok()
        {
            //  Arrange

            var wish = getTestWish();
            int id = wish.WishId;
            try
            {
                var controller = TestData.GetInjecteddController();

                //  Act
                var result = (OkNegotiatedContentResult<WishDto>)controller.Delete(id);

                //  Assert
                Assert.IsTrue(result.Content.MaxPrice == wish.MaxPrice);

                //  Cleanup
            }
            finally
            {
                cleanup(id);
            }
        }
        [TestMethod]
        public void Update_Ok()
        {
            //  Arrange

            var wish = getTestWish();
            int id = wish.WishId;
            try
            {
                OkNegotiatedContentResult<WishDto> result;

                //  Act
                using (var controller = TestData.GetInjecteddController())
                {
                    result = (OkNegotiatedContentResult<WishDto>)controller.Update(id);
                }

                //  Assert
                Assert.IsTrue(result.Content.MaxPrice == wish.MaxPrice);
            }
            finally
            {
                cleanup(wish.WishId);
            }
        }

        private void cleanup(int id)
        {
            WishEntity wish;
            using (TwnContext context = new TwnContext())
            {
                wish = context.Wishes.Find(id);
                context.Wishes.Remove(wish);
<<<<<<< Updated upstream
                context.Users.Remove(context.Users.Find(wish.UserId));
                context.SaveChanges();
            }
        }
    }
=======
                context.Users.Remove(context.Users.Find(wish.MadeById));
                context.SaveChanges();
            }
        }
    }*/
>>>>>>> Stashed changes
}