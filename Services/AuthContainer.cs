using Microsoft.IdentityModel.Tokens;
using MiraiSystem.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiraiSystem.Services
{
    public class AuthContainer : IAuthContainer
    {
        public string SecretKey { get; set; } = "supersecretkey";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.Aes128CbcHmacSha256;
        public Claim[] Claims { get; set; }
    }
}
