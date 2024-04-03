using System;
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
    public class IngressoController : ControllerBase
    {
       
        private readonly IngressoDAO _IngressoDAO;
 
        public IngressoController()
        {
            _IngressoDAO = new IngressoDAO();
        }
 
        [HttpGet]
        public IActionResult Get()
        {
            var Ingresso = _IngressoDAO.GetAll();
            return Ok(Ingresso);
        }
 
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var Ingresso = _IngressoDAO.GetId(id);
            if(Ingresso == null)
            {
                return NotFound();
            }
            return Ok(Ingresso);
        }
 
        [HttpPost]
        public IActionResult CriarIngresso(Ingresso ingresso)
        {
           _IngressoDAO.CriarIngresso(ingresso);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarIngresso(int id, Ingresso ingresso)
        {
        if(_IngressoDAO.GetId (id) == null)
        {
            return NotFound();
        }

        _IngressoDAO.AtualizarIngresso(id, ingresso);

        return Ok();
    
    
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarIngresso(int id)
        {
            if(_IngressoDAO.GetId(id) == null) return NotFound();
            _IngressoDAO.DeletarIngresso(id);
            return NoContent();

        }    
    
    }
}