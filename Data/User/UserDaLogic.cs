using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ThingsWeNeed.Data.Core;
using ThingsWeNeed.Data.Thing;
using ThingsWeNeed.Shared;

namespace ThingsWeNeed.Data.User
{
    public class UserDaLogic : IDisposable
    {
        public TwnContext DatabaseContext { get; private set; }

        public UserDaLogic()
        {
            DatabaseContext = new TwnContext();
        }

        /// <summary>
        /// Get user DTO by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User Data Transfer Object</returns>
        /// <exception cref="KeyNotFoundException">Datbase entry not found</exception>
        public UserDto GetById(int id)
        {
            UserEntity entity = DatabaseContext.Users.Find(id);

            if (entity != null)
            {
                UserDto dto = new UserDto()
                {
                    UserId = entity.UserId,
                    FName = entity.FName,
                    LName = entity.LName,
                    PhoneNumber = entity.PhoneNumber,
                    Username = entity.Username,
                    Email = entity.Email
                };
                return dto;
            }
            else
            {
                //  Use Key not found Exception for when a resource is not found
                throw new KeyNotFoundException();
            }
        }

        public IEnumerable<ThingDto> GetCollection()
        {
            throw new NotImplementedException();
        }

        public UserDto Create(
            string FName,
            string LName,
            string PhoneNumber,
            string Username,
            string Email
            )
        {

            UserEntity entity = new UserEntity();
            entity.FName = FName;
            entity.LName = LName;
            entity.PhoneNumber = PhoneNumber;
            entity.Username = Username;
            entity.Email = Email;

            DatabaseContext.Users.Add(entity);
            DatabaseContext.SaveChanges();


            UserDto dto = new UserDto()
            {
                UserId = entity.UserId,
                FName = entity.FName,
                LName = entity.LName,
                PhoneNumber = entity.PhoneNumber,
                Username = entity.Username,
                Email = entity.Email
            };
            
            return dto;
        }

        public void Update(
            int UserId,
            string FName,
            string LName,
            string PhoneNumber,
            string Username,
            string Email)
        {
            throw new NotImplementedException();
        }

        public UserDto Delete(int id)
        {
            UserEntity entity = DatabaseContext.Users.Find(id);
            if (entity != null)
            {
                DatabaseContext.Users.Remove(entity);

                UserDto dto = new UserDto()
                {
                    UserId = entity.UserId,
                    FName = entity.FName,
                    LName = entity.LName,
                    PhoneNumber = entity.PhoneNumber,
                    Username = entity.Username,
                    Email = entity.Email
                };

                DatabaseContext.SaveChanges();

                return dto;
            }
            else
            {
                throw (new KeyNotFoundException());
            }
        }

        public void Dispose() {
            DatabaseContext.Dispose();
        }

        public void InjectDatabaseContext(TwnContext context) {
            DatabaseContext = context;
        }
    }
}