using MyTest.Core;
using System;
using System.Configuration;


namespace MyTest.Infrastructure.Repositories
{
    public static class RepositoryFactory
    {
        public static IUserRepository CreateUserRepository()
        {
            string sType = ConfigurationManager.AppSettings.Get("ProviderType");
            Enum.TryParse(sType, out DataProviderType type);
            if (type == DataProviderType.SQL)
            {
                return new UserRepository(new ApplicationDbContext());
            }
            else if (type == DataProviderType.Mock)
            {
                return new MockUserRepositories();
            }
            else
            {
                return new UserRepository(new ApplicationDbContext());
            }
        }
        public static ICarRepository CreateCarRepository()
        {
            string sType = ConfigurationManager.AppSettings.Get("ProviderType");
            Enum.TryParse(sType, out DataProviderType type);
            if (type == DataProviderType.SQL)
            {
                return new CarRepository(new ApplicationDbContext());
            }
            else if (type == DataProviderType.Mock)
            {
                return new MockCarRepositories();
            }
            else
            {
                return new CarRepository(new ApplicationDbContext());
            }
        }
    }
}
