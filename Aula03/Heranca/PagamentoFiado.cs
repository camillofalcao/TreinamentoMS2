using System;
using System.Collections.Generic;
using System.Text;

namespace Heranca
{
    class PagamentoFiado : Pagamento
    {
        public PagamentoFiadoConsumo[] Consumos { get; set; }

        public override double ValorASerPago 
        {
            get
            {
                double total = 0;

                if (Consumos != null)
                    foreach (var item in Consumos)
                        total += item.SubTotal;

                return total;
            }
        }
    }
}
