using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.DAL;
using ThingsWeNeed.Models;

namespace Tests.Repositories
{
    class TestUnitOfWork : IUnitOfWork
    {
        private ModelContainer context;

        public TestUnitOfWork() {
            context = new ModelContainer();

            userRepository = new TestUserRepository(context);
            householdRepository = new TestHouseholdRepository(context);
            purchaseRepository = new TestPurchaseRepository(context);
            thingRepository = new TestThingRepository(context);
            wishRepository = new TestWishRepository(context);
        }

        private TestUserRepository userRepository;
        private TestHouseholdRepository householdRepository;
        private TestPurchaseRepository purchaseRepository;
        private TestThingRepository thingRepository;
        private TestWishRepository wishRepository;

        public IUserRepository UserRepository => userRepository;

        public IHouseholdRepository HouseholdRepository => householdRepository;

        public IPurchaseRepository PurchaseRepository => purchaseRepository;

        public IThingRepository ThingRepository => thingRepository;

        public IWishRepository WishRepository => wishRepository;

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
