using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository_Layer.Custom_Exception;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Utility
{
    public class JWTTokenGenerator
    {

        public static Task<string> generateToken(int id, string email,string role, IConfiguration _configuration)
        {
            try
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim("Id", id.ToString()),
                    new Claim("Email", email),
                    new Claim(ClaimTypes.Role,role)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                var jwttoken = new JwtSecurityTokenHandler().WriteToken(token);
                return Task.FromResult(jwttoken);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                throw new BookStoreException("Enable to get the Token for login");
            }
        }
    }
}
