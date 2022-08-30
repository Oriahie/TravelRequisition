using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelRequisition.Core.Interface.Services;
using TravelRequisition.Infrastructure.Models;

namespace TravelRequisition.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _auth;
        public AuthController(ITokenService auth)
        {
            _auth = auth;
        }

        [AllowAnonymous]
        [HttpPost("getToken")]
        public IActionResult GetToken()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Surname, "User"),
                new Claim(ClaimTypes.GivenName, "Test"),
                new Claim(JwtRegisteredClaimNames.Email, "testuser@gmail.com"),
                new Claim(JwtRegisteredClaimNames.Sub, "testuser@gmail.com"),
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
            };

            var token = _auth.GenerateAccessToken(claims);

            var res = new Response<TokenResponseModel>
            {
                Data = new TokenResponseModel { Token = token},
                Succeeded = true,
                Message = "Logged In Succesfully"
            };
            return Ok(res);
        }

    }
}
