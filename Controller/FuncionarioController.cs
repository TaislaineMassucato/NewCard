using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCard.Data;
using NewCard.Extensions;
using NewCard.Models;
using NewCard.ViewModels;

namespace NewCard.Controller
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet("v1/funcionarios")]

        public async Task<IActionResult> GetAsync([FromServices] NewCardContext context)
        {
            try
            {
                var fun = await context.Funcionarios.ToListAsync();

                return Ok(new ResultViewModel<List<Funcionario>>(fun));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Funcionario>>("05Xt2- Falha interna no Servidor"));
            }
        }

        [HttpGet("v1/funcionarios/{id}")]

        public async Task<IActionResult> GetAsync([FromRoute] int id, [FromServices] NewCardContext context)
        {
            try
            {
                var funcio = await context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
                if (funcio == null)
                    return NotFound(new ResultViewModel<Funcionario>("Funcionário não encontrado"));

                return Ok(new ResultViewModel<Funcionario>(funcio));
            }      
            catch
            {
                return StatusCode(500, new ResultViewModel<Funcionario>("05Xt4- Falha interna no Servidor"));
            }
        }

        [HttpPost("v1/funcionarios")]

        public async Task<IActionResult> PostAsync([FromBody]EditorFuncionarioViewModel funcionario, [FromServices] NewCardContext context)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Funcionario>(ModelState.GetErrors()));

            try
            {
                var funcio = new Funcionario
                {
                   Nome = funcionario.Nome,
                   Email = funcionario.Email,
                   Senha = funcionario.Senha,
                };

                await context.Funcionarios.AddAsync(funcio);
                await context.SaveChangesAsync();

                return Created($"v1/funcionarios/{funcio.Id}", new ResultViewModel<Funcionario>(funcio));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Funcionario>("05x43 - Não foi possivél incluir o Funcionário"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Funcionario>("05x45 - Falha interna no Servidor"));
            }
        }

        [HttpPut("v1/funcionarios/{id}")]

        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorFuncionarioViewModel funcio,[FromServices] NewCardContext context)
        {        
            try
            {               
                var fun = await context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
                if (fun == null)
                    return NotFound(new ResultViewModel<Funcionario>("Funcionário não encontrado"));

                fun.Nome = funcio.Nome;
                fun.Email = funcio.Email;
                fun.Senha = funcio.Senha;             

                context.Funcionarios.Update(fun);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Funcionario>(fun));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Funcionario>("05Xt6- Informações do Funcionario não correspondente"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Funcionario>("05Xt7- Falha interna no Servidor"));
            }
        }

        [HttpDelete("v1/funcionarios/{id}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] NewCardContext context)
        {
            try
            {
                var fun = await context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
                if (fun == null)
                    return NotFound(new ResultViewModel<Funcionario>("Funcionário não encontrado"));

                context.Funcionarios.Remove(fun);
                await context.SaveChangesAsync();

                return Ok($"Funcionario Id({fun.Id}) Nome({fun.Nome}) deletado com Sucesso");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Funcionario>("05Xt8- Id do Funcionario não correspondente"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Funcionario>( "05Xt9- Falha interna no Servidor"));
            }
        }
    }
}
