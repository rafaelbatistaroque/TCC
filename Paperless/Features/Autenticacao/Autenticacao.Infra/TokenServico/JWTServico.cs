using Autenticacao.Business.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autenticacao.Infra.TokenServico
{
    public class JWTServico : IJWT
    {
        private readonly IConfiguration _config;

        public JWTServico(IConfiguration config)
        {
            _config = config;
        }

        public string GerarToken(string identificador, string perfil)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(_config.GetSection("ChaveSecreta").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, identificador),
                    new Claim(ClaimTypes.Role, perfil)
                }),
                Expires = DateTime.UtcNow.AddHours(20),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
