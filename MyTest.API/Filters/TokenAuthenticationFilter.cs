using MyTest.Core.Enitity;
using MyTest.Infrastructure.Repositories;
using MyTest.Infrastructure.Utility;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MyTest.API.Filters
{
    public class TokenAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;
        IUserRepository _userRepository = null;
        public TokenAuthenticationAttribute()
        {
            _userRepository = RepositoryFactory.CreateUserRepository();
        }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            if (!request.RequestUri.AbsolutePath.EndsWith("Login"))
            {
                var authHeader = request.Headers.Where(s => string.Compare(s.Key, "x-auth-token", true) == 0).FirstOrDefault();


                if (authHeader.Key == null)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid auth token", request);
                    return;
                }

                if (!TokenHelper.ValidateCurrentToken(authHeader.Value.FirstOrDefault().ToString()))
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid auth token", request);
                    return;
                }
                string UserName = TokenHelper.GetClaim(authHeader.Value.FirstOrDefault(), "UserName");
                User user = _userRepository.Get(UserName);
                if (user == null || !user.IsLoggedIn)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid auth token", request);
                    return;
                }
            }

        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

    }
}