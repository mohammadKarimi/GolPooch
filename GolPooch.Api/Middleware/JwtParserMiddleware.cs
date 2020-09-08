using System;
using Elk.Core;
using System.Text;
using System.Linq;
using Elk.AspNetCore;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GolPooch.Api
{
    public class JwtParserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtService _jwtService;
        private readonly JwtSettings _jwtSettings;

        public JwtParserMiddleware(RequestDelegate next, IJwtService jwtService,
            IOptions<JwtSettings> jwtSettings)
        {
            _next = next;
            _jwtService = jwtService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            try
            {
                if (token != null)
                {
                    //var userClaims = _jwtService.GetClaimsPrincipal(token, _jwtSettings);
                    var userClaims = GetClaimsPrincipal(token, _jwtSettings);
                    if (userClaims != null)
                        context.Request.Headers.Add("UserId", userClaims.FindFirstValue("UserId"));
                }
                else
                {
                    if (context.Request.Headers["UserId"].FirstOrDefault() != null)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/Json";
                        var bytes = Encoding.ASCII.GetBytes(new Response<object> { IsSuccessful = false, Message = "UnAuthorized Access To Api !. Token Not Sent.", ResultCode = 401 }.SerializeToJson());
                        await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                    }
                }

                await _next(context);
            }
            catch (Exception e)
            {
                byte[] bytes;
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/Json";
                if (e.Message.Contains("Lifetime validation failed"))
                {
                    #region Expired Token
                    var validationTime = GetTokenExpireTime(token, _jwtSettings);
                    bytes = Encoding.ASCII.GetBytes(new Response<object>
                    {
                        ResultCode = 401,
                        IsSuccessful = false,
                        Message = $"UnAuthorized Access To Api ! Token Has Expired. Token Was Valid From: {validationTime.ValidFrom} Until To: {validationTime.ValidTo}",
                    }.SerializeToJson());
                    #endregion
                }
                else
                {
                    #region Another Exception
                    bytes = Encoding.ASCII.GetBytes(new Response<object>
                    {
                        ResultCode = 401,
                        IsSuccessful = false,
                        Message = $"UnAuthorized Access To Api ! Token Has Invalid. {e.Message}",
                    }.SerializeToJson());
                    #endregion
                }

                await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        public ClaimsPrincipal GetClaimsPrincipal(string token, JwtSettings jwtSettings)
        {
            var secretKey = Encoding.UTF8.GetBytes(!string.IsNullOrWhiteSpace(jwtSettings.SecretKey) ? jwtSettings.SecretKey : "<-- Mehran@Norouzi|123456789987654321|Mehran@Norouzi -->"); // Longer than 16 character
            var issuerSigningKey = new SymmetricSecurityKey(secretKey);

            var encryptionkey = Encoding.UTF8.GetBytes(!string.IsNullOrWhiteSpace(jwtSettings.Encryptionkey) ? jwtSettings.Encryptionkey : "<Mehran@Norouzi>"); //Must be 16 character
            var tokenDecryptionKey = new SymmetricSecurityKey(encryptionkey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = !string.IsNullOrEmpty(jwtSettings.Issuer),
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = !string.IsNullOrEmpty(jwtSettings.Audience),
                ValidAudience = jwtSettings.Audience,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                TokenDecryptionKey = tokenDecryptionKey,
                IssuerSigningKey = issuerSigningKey
            };

            var principal = new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.Aes128KW, StringComparison.InvariantCultureIgnoreCase)) return null;

            return principal;
        }

        public dynamic GetTokenExpireTime(string token, JwtSettings jwtSettings)
        {
            var secretKey = Encoding.UTF8.GetBytes(!string.IsNullOrWhiteSpace(jwtSettings.SecretKey) ? jwtSettings.SecretKey : "<-- Mehran@Norouzi|123456789987654321|Mehran@Norouzi -->"); // Longer than 16 character
            var issuerSigningKey = new SymmetricSecurityKey(secretKey);

            var encryptionkey = Encoding.UTF8.GetBytes(!string.IsNullOrWhiteSpace(jwtSettings.Encryptionkey) ? jwtSettings.Encryptionkey : "<Mehran@Norouzi>"); //Must be 16 character
            var tokenDecryptionKey = new SymmetricSecurityKey(encryptionkey);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = !string.IsNullOrEmpty(jwtSettings.Issuer),
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = !string.IsNullOrEmpty(jwtSettings.Audience),
                ValidAudience = jwtSettings.Audience,
                ValidateLifetime = false,
                ClockSkew = TimeSpan.Zero,
                TokenDecryptionKey = tokenDecryptionKey,
                IssuerSigningKey = issuerSigningKey
            };

            new JwtSecurityTokenHandler().ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            return new { jwtSecurityToken.ValidFrom, jwtSecurityToken.ValidTo };
        }
    }
}