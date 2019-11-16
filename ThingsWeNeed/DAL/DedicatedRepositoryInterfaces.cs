using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;

//  File for storing dedicated interfaces for each repository
//  Add any entity-specific methods here
namespace ThingsWeNeed.DAL
{
    public interface IHouseholdRepository : IGenericRepository<Household>
    {

    }

    public interface IThingRepository : IGenericRepository<Thing>
    {

    }

    public interface IUserRepository : IGenericRepository<AppUser>
    {

    }

    public interface IWishRepository : IGenericRepository<Wish>
    {

    }

    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {

    }

}
