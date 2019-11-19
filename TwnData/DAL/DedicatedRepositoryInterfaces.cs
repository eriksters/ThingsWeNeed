using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  File for storing dedicated interfaces for each repository
//  Add any entity-specific methods here
namespace TwnData
{
    public interface IHouseholdRepository : IGenericRepository<Household>
    {

    }

    public interface IThingRepository : IGenericRepository<Thing>
    {

    }

    public interface IUserRepository : IGenericRepository<AppUser>
    {
        AppUser GetUserWithHouseholdAndThingData(int id);
    }

    public interface IWishRepository : IGenericRepository<Wish>
    {

    }

    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {

    }

}
