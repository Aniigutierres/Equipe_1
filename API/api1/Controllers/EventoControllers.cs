using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAO;
using api.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
       
        private readonly EventoDAO _eventoDAO;
 
        public EventoController()
        {
            _eventoDAO = new EventoDAO();
        }
 
        [HttpGet]
        public IActionResult Get()
        {
            var evento = _eventoDAO.GetAll();
            return Ok(evento);
        }
 
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var evento = _eventoDAO.GetId(id);
            if(evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }
 
        [HttpPost]
        public IActionResult CriarEvento(Evento evento)
        {
           _eventoDAO.CriarEvento(evento);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarEvento(int id, Evento evento)
        {
        if(_eventoDAO.GetId (id) == null)
        {
            return NotFound();
        }

        _eventoDAO.AtualizarEvento(id, evento);

        return Ok();
    
    
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEvento(int id)
        {
            if(_eventoDAO.GetId(id) == null) return NotFound();

            _eventoDAO.DeletarEvento(id);

            return Ok();

        }    
    
    }
}