using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace api.models
{
    public class Pedido
    {
       [Column("idpedido")]
        public int Idpedido { get; set; }
 
        [Column("data")]
        public DateTime Data { get; set; }
 
        [Column("total")]
        public string? Total { get; set; }
 
        [Column("quantidade")]
        public int? Quantidade { get; set; }
 
        [Column("forma_pagamento")]
        public string? FormaPagamento { get; set; }
 
        [Column("ativo")]
        public int Ativo { get; set; }
 
        [Column("validacao_id_usuario")]
        public string? ValidacaoIdUsuario { get; set; }
    }
}