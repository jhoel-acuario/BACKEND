
using ApiWEb.DataAccess;
using ApiWEb.Helpers;
using ApiWEb.Models.DataModels;
using ApiWEb.Models.UserValidatorToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiWEb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private JwtSetting _jwtSetting;
        private readonly UniversityDbContext _context;
        public AccountController(JwtSetting jwtSetting, UniversityDbContext context) {
            _jwtSetting = jwtSetting;
            _context = context;
        }
        //TODO: CAMBIAR POR USUARIO REALES DE DB
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email="jhoel.sv25@gmail.com",
                Name="admin",
                Lastname="Silvestre",
                Password="admin"
            },
            new User()
            {
                Id = 2,
                Email="pep.sv25@gmail.com",
                Name="User 1",
                Password="admin"
            }
        };
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var Validate = Logins.Any(user=>user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase)); 
                if (Validate)
                {
                    var user = Logins.FirstOrDefault(user=>user.Name.Equals(userLogins.UserName,StringComparison.OrdinalIgnoreCase));
                    Token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName= user.Name,
                        EmailId= user.Email,
                        Id= user.Id,
                        GuidId= Guid.NewGuid()

                    }, _jwtSetting);
                }
                else
                {
                    return BadRequest("Password/User Invalid");
                }
                return Ok(Token);

            }catch(Exception ex)
            {
                throw new Exception("GetToken Error: ", ex);
            }
        }
        [HttpGet]
        [Authorize (AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
