using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCard.Data;
using NewCard.Extensions;
using NewCard.Models;
using NewCard.Services;
using NewCard.ViewModels;
using SecureIdentity.Password;
using System.Runtime.Intrinsics;

namespace NewCard.Controller
{
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost("v1/conta/")]
        public async Task<IActionResult> Post([FromBody]RegistroViewModel model, [FromServices]NewCardContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

             var funcio = new Funcionario
            {
                Nome = model.Nome,
                Email = model.Email,
            };

            //gerar senha automatica (mandar por email)=>(PACKAGE: SecureIdentity)
            //Salvando no banco modo randomico(dinamico)

            //gerar senha
            var senha = PasswordGenerator.Generate(25,true,false);

            //criptografar senha
            funcio.Senha = PasswordHasher.Hash(senha);

            try
            {
                await context.Funcionarios.AddAsync(funcio);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new {
                    funcio = funcio.Email, senha
                }));

            }
            catch(DbUpdateException)
            {
                return StatusCode(400, new ResultViewModel<string>("05VGS- Este email já está cadastrado!!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Funcionario>>("05Xt2- Falha interna no Servidor"));
            }
        }

        [HttpPost("v1/conta/login")]
        public IActionResult Login([FromServices] TokenService tokenService) 
        {
            var token = tokenService.GerarToken(null);

            return Ok(token);

        }
    }
}
