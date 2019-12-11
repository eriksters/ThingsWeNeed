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

        public UserDto[] GetCollection(int householdId)
        {
            // keep track which households the user belongs to
            ICollection<UserEntity> entityUsers = DatabaseContext.Households.Find(householdId).Users;

            // list of household dto
            ICollection<UserDto> userDtos = new List<UserDto>();

            // create household Dto for every household id
            foreach (UserEntity ue in entityUsers)
            {
                userDtos.Add(buildDto(ue));
            }

            //return the colletion
            return userDtos.ToArray();
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

        public UserDto Update(UserEntity entity)
        {
            UserEntity UserEntity = DatabaseContext.Users.Find(entity.UserId);
            UserEntity.FName= entity.FName;
            UserEntity.LName = entity.LName;
            UserEntity.PhoneNumber = entity.PhoneNumber;
            UserEntity.Username = entity.Username;
            UserEntity.Email = entity.Email;

            DatabaseContext.SaveChanges();

            UserDto UserDto = buildDto(UserEntity);
            return UserDto;
        }

        public bool Delete(int id)
        {
            UserEntity userEntity = DatabaseContext.Users.Find(id);
            UserEntity userRemoved = DatabaseContext.Users.Remove(userEntity);
            return userRemoved.UserId == id ? true : false;
        }

        public UserDto buildDto(UserEntity entity)
        {
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
                throw new KeyNotFoundException();
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