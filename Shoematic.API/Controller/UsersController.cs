using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shoematic.API.Dto;
using Shoematic.Data;
using Shoematic.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shoematic.API.Controller
{
    public class UsersController : BaseController
    {
        public ShoematicDbContext DbContext { get; set; }
        private readonly JwtSettings _Jwt;
        public UsersController(ShoematicDbContext context, IOptions<JwtSettings> jwt)
        {
            DbContext = context;
            _Jwt = jwt.Value;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> Authenticate(LoginRequestDto requestDto)
        {
            if(requestDto == null) 
                return StatusCode(404,"User Not Found, Please Enter Correct User info");

            var user =await DbContext.Users
                .FirstOrDefaultAsync(user=>user.Email==requestDto.UserEmail
                && user.IsAdmin == requestDto.IsAdmin);
            
            if(user == null) 
                return StatusCode(404,"User Not Found, Please Enter Correct User info");

            if (user.Password != requestDto.Password)
                return StatusCode(404, $"Incorrect Password for {user.Email}, Please Enter Correct password");

            var jwtToken = GenerateToken(user);

            return StatusCode(200, jwtToken);
        }
        [HttpPost("SignUp")]
        public async Task<bool> CreateUser(SignUpRequestDto requestDto)
        {
            if (requestDto == null) return false;
            var newUser = new User()
            {
                Address = requestDto.Address,
                Email = requestDto.Email,
                Gender = requestDto.Gender,
                Password = requestDto.Password,
                UserName = requestDto.Name,
                IsAdmin = false
            };
            DbContext.Users.Add(newUser);
            await DbContext.SaveChangesAsync();
            return true;
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_Jwt.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(_Jwt.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
