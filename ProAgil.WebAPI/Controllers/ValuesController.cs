using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context){ _context = context; }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _context.Eventos.ToListAsync();
                return Ok(eventos);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve problemas de comunicação com o banco de dados.");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var eventoResultado = await _context.Eventos.Where(evento => evento.EventoId == id).FirstOrDefaultAsync();

                if(eventoResultado != null)
                    return Ok(eventoResultado);
                else
                    return NotFound("Não foi encontrado nenhum evento"); 
            }
            catch{
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Houve problemas de comunicação com o banco de dados");
            }                                                  
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
