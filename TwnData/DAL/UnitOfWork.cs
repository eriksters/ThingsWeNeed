using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwnData
{
    public class UnitOfWork : IUnitOfWork
    {
        private TwnContext context;
        
        private IUserRepository userRepository;
        private IHouseholdRepository householdRepository;
        private IPurchaseRepository purchaseRepository;
        private IThingRepository thingRepository;
        private IWishRepository wishRepository;

        public UnitOfWork(TwnContext context)
        {
            this.context = context;
        }

        public TwnContext Context => context;

        public IUserRepository UserRepository { 
            get {
                if (userRepository == null) 
                    this.userRepository = new UserRepository(context);

                return userRepository;
            }
        }

        public IHouseholdRepository HouseholdRepository {
            get {
                if (householdRepository == null)
                    householdRepository = new HouseholdRepository(context);

                return householdRepository;
            }
        }

        public IPurchaseRepository PurchaseRepository {
            get {
                if (purchaseRepository == null)
                    purchaseRepository = new PurchaseRepository(context);

                return purchaseRepository;
            }
        }

        public IThingRepository ThingRepository {
            get {
                if (thingRepository == null)
                    thingRepository = new ThingRepository(context);

                return thingRepository;
            }
        }

        public IWishRepository WishRepository {
            get {
                if (wishRepository == null)
                    wishRepository = new WishRepository(context);

                return wishRepository;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}