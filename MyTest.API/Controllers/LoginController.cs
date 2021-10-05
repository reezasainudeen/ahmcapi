using MyTest.API.Filters;
using MyTest.Core.Enitity;
using MyTest.Infrastructure.Repositories;
using MyTest.Infrastructure.Utility;
using System.Web.Http;

namespace MyTest.API.Controllers
{  
    public class LoginController : ApiControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginController()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public LoginController(IUserRepository userRepository) : base(userRepository)
        {

        }
        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [IdentityBasicAuthenticationAttribute]
        [HttpPut]       
        public IHttpActionResult Put()
        {
            User user = new User { Name = RequestContext.Principal.Identity.Name };
            User loginUser = _userRepository.LoginUser(user);
            var token = TokenHelper.GenerateUserToken(loginUser);
            return Ok(token);
        }
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            var bSuccess = _userRepository.RegisterUser(user); ;
            return Ok(bSuccess);
        }

    }
}