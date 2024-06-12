using AutoMapper;
using EgyDynamics2.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EgyDynamics2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UnitOf_Work unitofwork;
        IMapper mapper;

        public LoginController(UnitOf_Work unitofwork, IMapper mapper)
        {
            this.unitofwork = unitofwork;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult login(string email, string password)
        {
            var user = unitofwork.EployeeRepository.FirstOrDefault(s => s.اسمالمستخدم == email && s.كلمةالمرور == password);
            if (user != null)
            {

                #region claims   
                List<Claim> userdata = new List<Claim>();
                userdata.Add(new Claim("id", user.كودالموظف.ToString()));
                #endregion

                #region secret key
                string key = "welcome to my secret key PetBook Alex";
                var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                var signingcer = new SigningCredentials(secertkey, SecurityAlgorithms.HmacSha256);
                #endregion

                #region generate token 
                //header =>hashing algo
                //payload=>claims,expiredate
                //signture => secertkey
                var token = new JwtSecurityToken(
                    claims: userdata,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingcer
                    );

                //token object => encoded string
                //var tokenobjhand = new JwtSecurityTokenHandler();
                //var finaltoken= tokenobjhand.WriteToken(token);
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion

                return Ok(tokenstring);

            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
