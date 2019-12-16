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
using ThingsWeNeed.Shared;

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

        public void Update(UserDto dto) {
            UserEntity entity = Store.FindByIdAsync(dto.Id).GetAwaiter().GetResult();
            entity.FName = dto.FName;
            entity.LName = dto.LName;
            UpdateAsync(entity);
        }

        public UserDto Get (string userId) {

            var entity = base.FindByIdAsync(userId).GetAwaiter().GetResult();

            UserDto dto = new UserDto() { 
                Email = entity.Email,
                FName = entity.FName,
                LName = entity.LName,
                Id = entity.Id,
                Username = entity.UserName,
                PhoneNumber = entity.PhoneNumber
            };

            return dto;

        } 
    }
}