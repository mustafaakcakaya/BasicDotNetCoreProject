using Bootcamp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp2.Context
{
    public class UserContext
    {
        public List<UserEntity> Users { get; set; }
        public UserContext()
        {
            Users = new List<UserEntity>
            {
                new UserEntity
                {
                    Id = 1,
                    Name = "Hazel",
                    Surname = "Cakli",
                    BirthDate = DateTime.Now.AddYears(-31),
                     Gender = "Kadın",
                      Email="email.email@gmail.com",
                       GithubAccountUrl="emailcigithub"

                },
                new UserEntity
                {
                    Id = 2,
                    Name = "Berna",
                    Surname = "İkiz",
                    BirthDate = DateTime.Now.AddYears(-23),
                     Gender = "Kadın",
                      Email="email.biirna@gmail.com",
                       GithubAccountUrl="emailcigithub"

                },
                new UserEntity
                {
                    Id = 3,
                    Name = "Mustafa",
                    Surname = "Akçakaya",
                    BirthDate = DateTime.Now.AddYears(-25),
                     Gender = "Erkek",
                      Email="email.mistaa@gmail.com",
                       GithubAccountUrl="emailcigithub"

                }
            };
        }
    }
}
