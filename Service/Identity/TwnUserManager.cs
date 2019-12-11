using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.User;

namespace ThingsWeNeed.Service.Identity
{
    public class TwnUserManager : UserManager<UserEntity>
    {
        public TwnUserManager(UserStore<UserEntity> userStore) : base(userStore)
        {
        }

        public static TwnUserManager Create(IdentityFactoryOptions<TwnUserManager> options, IOwinContext context) {
            var manager = new TwnUserManager(new UserStore<UserEntity>(context.Get<TwnContext>()));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            return manager;
        }
    }
}