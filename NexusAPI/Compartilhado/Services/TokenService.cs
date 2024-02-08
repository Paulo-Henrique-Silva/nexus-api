using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NexusAPI.Compartilhado.Services
{
    public class TokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GerarToken(string usuarioUID, string nomeAcesso)
        {
            //Cria as claims conforme UID e nomeAcesso do usuário.
            var claims = new[]
            {
                new Claim("UID", usuarioUID),
                new Claim("nomeAcesso", nomeAcesso),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var chaveSecreta = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration["Logging:Auth:chave"]));

            var credenciais = new SigningCredentials(chaveSecreta, SecurityAlgorithms.HmacSha256);
            var expiracao = DateTime.Now.AddMinutes(30);

            //Cria token que irá se expirar em 30 minutos.
            var token = new JwtSecurityToken(
                issuer: configuration["Logging:Auth:issuer"],
                audience: configuration["Logging:Auth:audience"],
                claims: claims,
                expires: expiracao,
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string ObterUsuarioUID(IEnumerable<Claim> claims)
        {
            // Recuperar o ID do usuário do token JWT
            var uidClaim = claims.FirstOrDefault(c => c.Type == "UID");

            if (uidClaim != null)
            {
                return uidClaim.Value;
            }

            throw new Exception("UID não encontrado na claim.");
        }
    }
}
