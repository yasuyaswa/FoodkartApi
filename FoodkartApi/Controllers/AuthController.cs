using AutoMapper;
using FoodkartApi.DataModels;
using FoodkartApi.DataModels.Customer;
using FoodkartApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FoodkartApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public static Admin admin = new Admin();
        private readonly FoodAppContext _FoodAppContext;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration, FoodAppContext FoodAppContext, IMapper mapper)
        {
            this.mapper = mapper;
            _configuration = configuration;
            _FoodAppContext = FoodAppContext;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AdminCreateDto>> Register(AdminCreateDto request)
        {
            var user = mapper.Map<Admin>(request);
            await _FoodAppContext.Admins.AddAsync(user);
            await _FoodAppContext.SaveChangesAsync();
            CreatePasswordHash(request.AdminPass, out byte[] passwordHash, out byte[] passwordSalt);
            admin.UserId= request.UserId;
            admin.AdminPass = request.AdminPass;
            admin.AdminPasswordHash = passwordHash;
            admin.AdminPasswordSalt = passwordSalt;

            return Ok(admin);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(AdminCreateDto request)
        {
            if (admin.UserId != request.UserId)
            {
                return BadRequest("Admin not found.");
            }
            if (!VerifyPasswordHash(request.AdminPass, admin.AdminPasswordHash, admin.AdminPasswordSalt))
            {
                return BadRequest("Wrong Password");
            }
            string token = CreateToken(admin);
            return Ok(token);
        }

        private string CreateToken(Admin admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,admin.UserId)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(admin.AdminPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}