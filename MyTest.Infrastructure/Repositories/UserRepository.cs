using MyTest.Core.Enitity;
using System.Data;
using System.Linq;

namespace MyTest.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User Get(string name)
        {
            return context.Users
                 .Where(c => c.Name == name)
                 .FirstOrDefault();
        }

        public User LoginUser(User user)
        {
            user.IsLoggedIn = true;
            return Update(user);
        }

        public bool RegisterUser(User user)
        {
            Add(user);
            return true;
        }

        public override User Update(User entity)
        {
            var User = context.Users
                .Single(c => c.Id == entity.Id);

            User.Name = entity.Name;
            User.Password = entity.Password;
            User.Email = entity.Email;
            User.IsLoggedIn = entity.IsLoggedIn;
            base.SaveChanges();
            return context.Users
                .Single(c => c.Id == entity.Id);
        }
        public override User Add(User entity)
        {
            context.Users.Add(entity);
            base.SaveChanges();
            return context.Users
                .Single(c => c.Name == entity.Name);
        }
    }  
}
