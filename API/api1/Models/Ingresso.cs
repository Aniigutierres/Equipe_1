using System.ComponentModel.DataAnnotations.Schema;
 
namespace api.Models
{
    public class Ingresso
    {  
        [Column("id_ingresso")]
        public int IdIngresso { get; set; }
 
        [Column("codigo_qr")]
        public string? CodigoQr {get; set;}
 
        [Column("valor")]
        public string? Valor { get; set; }
 
        [Column("status")]
        public string? Status { get; set; }
 
        [Column("tipo")]
        public string? Tipo { get; set; }
 
        [Column("pedido_id_pedido")]
        public string? PedidoIdPedido { get; set; }
 
        [Column("pedido_usuario_id_usuario")]
        public string? PedidoUsuarioIdUsuario { get; set; }
 
        [Column("lote_id_lote")]
        public string? LoteIdLote { get; set; }
 
        [Column("lote_evento_id_evento")]
        public string? LoteEventoIdEvento { get; set; }
 
       
    }
}