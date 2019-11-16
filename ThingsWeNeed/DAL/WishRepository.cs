using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class WishRepository : GenericRepository<Wish>, IWishRepository
    {
        private ModelContainer mc;

        public WishRepository(ModelContainer mc) : base(mc)
        {
            this.mc = mc;
        }
    }
}