using Microsoft.IdentityModel.Tokens;
using NewCard.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NewCard.Services
{
    public class TokenService
    {
        public string GerarToken(Funcionario funcionario)
        {
            //Manipulador Token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Capturar chave de string de discriptografar (Keyacesso)
            //Converter Bytes
            var key = Encoding.ASCII.GetBytes(Configuracao.JWTkey);

            //Descricao Token (Info)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
