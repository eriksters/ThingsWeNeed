using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThingsWeNeed.Models;

namespace ThingsWeNeed.DAL
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        private ModelContainer mc;

        public PurchaseRepository(ModelContainer mc) : base(mc)
        {
            this.mc = mc;
        }

    }
}
