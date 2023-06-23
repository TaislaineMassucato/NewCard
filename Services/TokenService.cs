using Microsoft.IdentityModel.Tokens;
using NewCard.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewCard.Services
{
    public class TokenService
    {
        public string GerarToken(Funcionario funcionario)
        {   
            //Manioulador de Token
            var handlerToken = new JwtSecurityTokenHandler();

            //CAPTURANDO tOKEN DE ACESSO PARA MANIPULAÇÃO
                //COVERTENDO PARA BYTE
            var key = Encoding.ASCII.GetBytes(Configuracao.JWTkey);

            //Infos (Descrição) token
            var infosToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Taislaine"),
                    new Claim(ClaimTypes.Role, "Funcionario"),
                    new Claim(ClaimTypes.Role, "Medico"),
                    new Claim("fruta", "banana"),
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            //Criando Token con base nas infos
            var token = handlerToken.CreateToken(infosToken);

            //convertendo token para string
            return handlerToken.WriteToken(token);

        }
    }
}
