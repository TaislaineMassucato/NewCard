using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCard.Data;
using NewCard.Extensions;
using NewCard.Models;
using NewCard.Services;
using NewCard.ViewModels;
using NewCard.ViewModels.Accounts;
using SecureIdentity.Password;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace NewCard.Controller
{
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost("v1/conta/")]
        public async Task<IActionResult> Post([FromBody]RegistroViewModel model, [FromServices]EmailService emailService, [FromServices]NewCardContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

             var funcio = new Funcionario
            {
                Email = model.Email,
                Nome = model.Nome,
                
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

                emailService.Send( 
                    funcio.Email,
                    funcio.Nome,
                    "Bem vindo a Clínica",
                    $"Sua senha de acesso é <strong>{senha}</strong>");

                return Ok(new ResultViewModel<dynamic>(new 
                {
                    funcio = funcio.Email,
                    senha
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

        //[Authorize]
        //[HttpPost("v1/conta/upload-image")]
        //public async Task<IActionResult> UploadImageAsync(
        //    [FromBody] UploadImageViewModel model,
        //    [FromServices] NewCardContext context)
        //{
        //    var fileName = $"{Guid.NewGuid().ToString()}.jpg";
        //    var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(model.Base64Image, "");
        //    var bytes = Convert.FromBase64String(data);

        //    try
        //    {
        //        await System.IO.File.WriteAllBytesAsync($"wwwroot/images/{fileName}", bytes);
        //    }
        //    catch
        //    {
        //        return StatusCode(500, new ResultViewModel<string>("0543 - Falha interna servidor"));
        //    }

        //    var medicu = await context.Medicos.FirstOrDefaultAsync(x => x.Email == Medico.Identity.Name);

        //    if (medicu == null)
        //        return NotFound(new ResultViewModel<Funcionario>("Funcionario não encontrado"));

        //    medicu.Image = $"http://localhost:0000/images/{fileName}";
        //    try
        //    {
        //       context.Medicos.Update(medicu);
        //        await context.SaveChangesAsync();
        //    }
        //    catch
        //    {
        //        return StatusCode(500, new ResultViewModel<string>("0543 - Falha interna servidor"));
        //    }
        //}

    }
}
