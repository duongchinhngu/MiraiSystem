using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiraiSystem.Services.IServices
{
    public interface IAuthContainer
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        Claim[] Claims { get; set; }
    }
}
