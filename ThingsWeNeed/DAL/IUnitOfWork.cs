using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository UserRepository { get; }
        HouseholdRepository HouseholdRepository {get;}
        PurchaseRepository PurchaseRepository { get; }
        ThingRepository ThingRepository { get; }
        WishRepository WishRepository { get; }
        void Save();

    }
}