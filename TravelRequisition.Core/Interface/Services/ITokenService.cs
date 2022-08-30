using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace TravelRequisition.Core.Interface.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
