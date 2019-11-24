using System;
using System.Collections.Generic;
using System.Text;

namespace TwnData
{
    public enum WishStatus : byte
    {
        Cancelled = 0,
        BoughtNotPaid = 1,
        BoughtPaid = 2,
        Pending = 3
    }
}
