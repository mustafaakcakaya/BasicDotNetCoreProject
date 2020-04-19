using Bootcamp2.Context;
using Bootcamp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp2.Services
{
    public class UserService
    {
        private readonly UserContext _userContext;
        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public void Add(UserEntity entity)
        {
            _userContext.Users.Add(entity);
        }

        public List<UserEntity>GetAll()
        {
            return _userContext.Users;
        }

        public UserEntity Get(int id)
        {
            return _userContext.Users.FirstOrDefault(x=>x.Id==id);
        }

        public List<UserEntity> Query(int id,string name, string surname)
        {
            return _userContext.Users.Where(x => 
                                            x.Id == id || 
                                            x.Name == name || 
                                            x.Surname == surname)
                .ToList();
        }
        public void Edit(UserEntity entity)
        {
            var entityToUpdate = _userContext.Users.FirstOrDefault();
        }
    }
}
