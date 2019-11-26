using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using TwnData;

namespace ThingsWeNeed.DAL
{
    public abstract class AbstractDaLogic : IDisposable
    {
        protected static TwnContext DatabaseContext { get; private set; }

        protected AbstractDaLogic()
        {
            if (DatabaseContext == null)
            {
                DatabaseContext = new TwnContext();  
            }
        }

        ///// <summary>
        ///// Check if the connection is still open. If not, try to open it again
        ///// </summary>
        ///// <returns>true if the connection was open, false if not</returns>
        //public bool CheckConnection()
        //{
        //    if (DatabaseContext.Database.Connection.State != ConnectionState.Open)
        //    {
        //        DatabaseContext.Database.Connection.Open();
        //        return false;
        //    }

        //    return true;
        //}

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }

        public void Dispose()
        {
            DatabaseContext.Dispose();
        }
    }
}