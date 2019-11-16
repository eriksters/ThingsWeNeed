using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.DAL;
using ThingsWeNeed.Models;

namespace UnitTests.Data
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
