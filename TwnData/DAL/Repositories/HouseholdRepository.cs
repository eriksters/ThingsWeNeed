using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwnData
{
    public class HouseholdRepository : GenericRepository<Household>, IHouseholdRepository
    {


        public HouseholdRepository(TwnContext mc) : base(mc, "dbo.Households")
        {
            
        }
    }
}