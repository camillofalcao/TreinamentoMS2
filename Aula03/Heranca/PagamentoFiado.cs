using System;
using System.Collections.Generic;
using System.Text;

namespace Heranca
{
    class PagamentoFiado : Pagamento
    {
        public PagamentoFiadoConsumo[] Consumo { get; set; }

        public override double ValorASerPago 
        {
            get
            {
                double total = 0;

                if (Consumo != null)
                    foreach (var item in Consumo)
                        total += item.SubTotal;
                
                return total;
            }
        }
    }
}
