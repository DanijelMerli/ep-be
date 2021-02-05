using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using EsportsProphetAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace EsportsProphetAPI.Security
{
    public class JWTGenerator : ITokenGenerator
    {
        public string GetTokenString(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes("danijel merli je najjaci na svetu majke mi");
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}