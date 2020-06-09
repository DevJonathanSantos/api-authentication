using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthentication.Services
{
    public class TokenService
    {
        public static async Task<string> GenerateToken(User user)
        {
            //Gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();
            //Converte a chave incripitada para byts
            var key = Encoding.ASCII.GetBytes(Contantes.Secret);
            //Passa as informaçõe para gerar o token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
