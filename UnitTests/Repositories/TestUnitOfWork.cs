using System;
using ThingsWeNeed.DAL;

namespace UnitTests.Repositories
{
    class TestUnitOfWork : IUnitOfWork
    {
        private IUserRepository userRepository;
        private IHouseholdRepository householdRepository;
        private IPurchaseRepository purchaseRepository;
        private IThingRepository thingRepository;
        private IWishRepository wishRepository;

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
