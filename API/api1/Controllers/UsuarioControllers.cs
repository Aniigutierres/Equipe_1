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
    public class UsuarioController : ControllerBase
    {
        private UsuarioDAO _usuarioDAO;

        public UsuarioController()
        {
            _usuarioDAO = new UsuarioDAO();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var usuario = _usuarioDAO.GetAll();
            return Ok(usuario);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var usuario = _usuarioDAO.GetId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario(Usuario usuario)
        {
            _usuarioDAO.CriarUsuario(usuario);
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            if (_usuarioDAO.GetId(id) == null)
            {
                return NotFound();
            }

            _usuarioDAO.AtualizarUsuario(id, usuario);

            return Ok();


        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletarUsuario(int id)
        {
            if (_usuarioDAO.GetId(id) == null) return NotFound();
            _usuarioDAO.DeletarUsuario(id);
            return NoContent();

        }

    }
}
