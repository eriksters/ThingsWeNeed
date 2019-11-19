using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwnData
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {

        public UserRepository(TwnContext mc) : base(mc)
        {

        }

        public AppUser GetUserWithHouseholdAndThingData(int id)
        {
            return base.entities
                .Include("Households")
                .Include("Households.Things")
                .Include("Households.Things.Purchases")
                .Single(x => x.UserId == id);
        }
    }
}