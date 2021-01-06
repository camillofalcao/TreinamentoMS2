using System;
using System.Collections.Generic;
using System.Text;

namespace Heranca
{
    abstract class Pagamento
    {
        public abstract double ValorASerPago { get; }
        
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double ValorPago { get; set; }
    }
}
