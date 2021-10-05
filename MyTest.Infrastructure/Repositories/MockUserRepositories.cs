using MyTest.Core.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyTest.Infrastructure.Repositories
{
    public class MockUserRepositories : IUserRepository
    {
        private static List<User>  _users = new List<User>
        {
            { new User { Id =1 , Name="TestUser1", Password="TestPWD1",Email="TestUser1@abc.com"} },
            { new User { Id =2 , Name="TestUser2", Password="TestPWD2",Email="TestUser2@abc.com"} },
            { new User { Id =3 , Name="TestUser3", Password="TestPWD3",Email="TestUser3@abc.com"} },
            { new User { Id =4 , Name="TestUser4", Password="TestPWD4",Email="TestUser4@abc.com"} },
            { new User { Id =5 , Name="TestUser5", Password="TestPWD5",Email="TestUser5@abc.com"} },
            { new User { Id =6 , Name="testuser", Password="Pass1word",Email="testuser@abc.com"} }
        };

        public User Get(string name)
        {
            return _users.Where(s => String.Compare(s.Name, name, false) == 0).FirstOrDefault(); ;
        }

        public User LoginUser(User user)
        {
            User loginUser = _users.Where(s => String.Compare(s.Name, user.Name, false) == 0).FirstOrDefault();
            if (loginUser != null)
            {
                loginUser.IsLoggedIn = true;
            }
            return loginUser;
        }

        public bool RegisterUser(User user)
        {
            if (user != null)
            {
                user.Id = _users.Count() + 1;
                _users.Add(user);
                return true;
            }
            return false;
        }   

    }
}
