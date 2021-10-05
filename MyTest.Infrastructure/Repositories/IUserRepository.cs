using MyTest.Core.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTest.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User Get(string name);
        bool RegisterUser(User user);
        User LoginUser(User user);
    }
}
