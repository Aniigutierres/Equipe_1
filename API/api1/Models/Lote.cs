using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
 
namespace api.Models
{
    public class Lote
    {
        [Column("id_lote")]
        public int IdLote { get; set; }
 
        [Column("id_eventos")]
        public int IdEventos { get; set; }
 
        [Column("valor_unitario")]
        public double ValorUnitario { get; set; }
 
        [Column("quantidade_total")]
        public int QuantidadeTotal { get; set; }
 
        [Column("saldo")]
        public int Saldo { get; set; }
 
         [Column("ativo")]
        public int Ativo { get; set; }
       
    }
}