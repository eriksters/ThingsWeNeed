﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IHouseholdRepository HouseholdRepository {get;}
        IPurchaseRepository PurchaseRepository { get; }
        IThingRepository ThingRepository { get; }
        IWishRepository WishRepository { get; }
        void Commit();

    }
}