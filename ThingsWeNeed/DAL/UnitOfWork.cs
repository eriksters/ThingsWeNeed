using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ModelContainer context;
        private UserRepository userRepository;
        private HouseholdRepository householdRepository;
        private PurchaseRepository purchaseRepository;
        private ThingRepository thingRepository;
        private WishRepository wishRepository;

        public UnitOfWork()
        {
            context = new ModelContainer();
        }

        public ModelContainer Context => context;

        public UserRepository UserRepository { 
            get {
                if (userRepository == null) 
                    this.userRepository = new UserRepository(context);

                return userRepository;
            }
        }

        public HouseholdRepository HouseholdRepository {
            get {
                if (householdRepository == null)
                    householdRepository = new HouseholdRepository(context);

                return householdRepository;
            }
        }

        public PurchaseRepository PurchaseRepository {
            get {
                if (purchaseRepository == null)
                    purchaseRepository = new PurchaseRepository(context);

                return purchaseRepository;
            }
        }

        public ThingRepository ThingRepository {
            get {
                if (thingRepository == null)
                    thingRepository = new ThingRepository(context);

                return thingRepository;
            }
        }

        public WishRepository WishRepository {
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

        public void Save()
        {
            context.SaveChanges();
        }
    }
}