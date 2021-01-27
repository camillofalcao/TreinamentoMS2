using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkEDAO.Models
{
    class Pedido
    {
        public string PedidoId { get; set; }
        public int Numero { get; set; }
        
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public IList<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
        public double Total => Itens.Sum(x => x.SubTotal);
    }
}
