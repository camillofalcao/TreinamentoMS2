using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    interface IPagamentoInfo
    {
        DateTime DataEmissao { get; set; }
        DateTime DataVencimento { get; set; }
        DateTime DataPagamento { get; set; }
        
        double ValorPago { get; set; }
    }
}
