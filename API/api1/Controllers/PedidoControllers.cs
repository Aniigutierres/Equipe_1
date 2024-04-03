using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DAO;
using api.models;
using Microsoft.AspNetCore.Mvc;
 
 
 
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private PedidoDAO _pedidoDAO;
        private object pedido;
 
        public PedidoController()
        {
            _pedidoDAO = new PedidoDAO();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var pedido = _pedidoDAO.GetAll();
            return Ok(pedido);
        }
   
    [HttpGet("{id}")]
    public IActionResult GetId(int id)
    {
        var pedido = _pedidoDAO.GetId(id);
        if(pedido== null)
        {
            return NotFound();
        }
        return Ok(pedido);
    }
   
    [HttpPost]
    public IActionResult CriarPedido(Pedido pedido)
    {
         _pedidoDAO.CriarPedido(pedido);
        return Ok ();
    }
    [HttpPut("{id}")]
    public IActionResult AtualizarPedido(int id, Pedido pedido)
    {
        if(_pedidoDAO.GetId (id) == null)
        {
            return NotFound();
        }
 
        _pedidoDAO.AtualizarPedido(id, pedido);
 
        return Ok();
   
   
        }
 
        [HttpDelete("{id:int}")]
        public IActionResult DeletarPedido(int id)
        {
            if(_pedidoDAO.GetId(id) == null) return NotFound();
            _pedidoDAO.DeletarPedido(id);
            return NoContent();
 
        }    
   
    }
}