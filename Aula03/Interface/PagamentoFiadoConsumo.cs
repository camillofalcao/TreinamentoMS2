using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class PagamentoFiadoConsumo
    {
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double SubTotal { get => Quantidade * ValorUnitario; }
    }
}
