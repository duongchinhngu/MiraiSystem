using Microsoft.IdentityModel.Tokens;
using MiraiSystem.Models;
using MiraiSystem.Services.IServices;
using MiraiSystem.UnitOfWorks;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MiraiSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthContainer authContainer;

        public AuthService(IUnitOfWork unitOfWork, IAuthContainer authContainer)
        {
            this.unitOfWork = unitOfWork;
            this.authContainer = authContainer;
        }

        public async Task<SecurityToken> Authenticate(string email)
        {
            User userCheck = await unitOfWork.UserRepository.GetByEmail(email);
            if (userCheck == null)
            {
                return null;
            }

            var securityKey = GetSymmetricSecurityKey();

            var signinCredentials = new SigningCredentials(securityKey, authContainer.SecurityAlgorithm);

            authContainer.Claims = new Claim[]
            {
                new Claim("ID", userCheck.Id),
                new Claim("Email", userCheck.Email),
                new Claim("ProfileUrl", userCheck.ProfileUrl),
                new Claim("Phone", userCheck.Phone),
            };

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "mirai system audience",
                Subject = new ClaimsIdentity(authContainer.Claims),
                SigningCredentials = signinCredentials,
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "Mirai System Issuer",
            };

            //SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = "Mirai System Issuer",
            //    Audience = "mirai system audience",
            //    Subject = new ClaimsIdentity(authContainer.Claims),
            //    SigningCredentials = signinCredentials,
            //    Expires = DateTime.UtcNow.AddDays(7),
            //};

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            //string tokenString = tokenHandler.WriteToken(securityToken);
            return securityToken;
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(authContainer.SecretKey);
            return new SymmetricSecurityKey(key);
        }
    }
}
