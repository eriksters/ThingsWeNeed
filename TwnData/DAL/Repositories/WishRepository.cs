using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwnData
{
    public class WishRepository : GenericRepository<Wish>, IWishRepository
    {

        public WishRepository(TwnContext mc) : base(mc)
        {
        }
    }
}