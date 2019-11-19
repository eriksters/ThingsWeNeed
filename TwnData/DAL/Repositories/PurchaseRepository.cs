using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwnData
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {

        public PurchaseRepository(TwnContext mc) : base(mc)
        {

        }

    }
}
