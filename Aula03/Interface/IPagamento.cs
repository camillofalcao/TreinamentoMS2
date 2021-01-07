using System;

namespace Interface
{
    interface IPagamento
    {
        double ValorASerPago { get; }
        DateTime DataEmissao { get; set; }
        DateTime DataVencimento { get; set; }
        DateTime DataPagamento { get; set; }
        double ValorPago { get; set; }

        public void Pagar(double valor);
    }
}
