using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agenda.ViewModels;

namespace Agenda.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public async Task <IActionResult> GetAsync([FromServices]AppDbContext context)
        {
            var contatos = await context.Contatos.ToListAsync();
            return Ok(contatos);
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromServices]AppDbContext context)
        {
            var oContato = context.Contatos.Find(id);

            if(oContato is null) return NotFound();
            
            return Ok(oContato);
        }

        [HttpPost("/")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateContatoVM umContato,
            [FromServices]AppDbContext context)
        {
            var NovoContato = new Contato
            {
                //Id= umContato.Codigo,
                Nome = umContato.NomeCompleto,
                Telefone = umContato.Telefone,
                DataNascimento = umContato.DataDeNascimento
            };
            await context.Contatos.AddAsync(NovoContato);
            await context.SaveChangesAsync();
            
            return Created($"/{NovoContato.Id}", umContato);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put(
            [FromRoute] int id,
            [FromBody] Contato umContato,
            [FromServices]AppDbContext context)
        {
            var oContato = context.Contatos.Find(id);

            if(oContato is null) return NotFound();

            oContato.Nome = umContato.Nome;
            oContato.DataNascimento = umContato.DataNascimento;
            oContato.Telefone = umContato.Telefone;

            context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,            
            [FromServices]AppDbContext context)
        {
            var oContato = context.Contatos.Find(id);

            if(oContato is null) return NotFound();

            context.Contatos.Remove(oContato);
            context.SaveChanges();
            
            return NoContent();
        }
    }
}