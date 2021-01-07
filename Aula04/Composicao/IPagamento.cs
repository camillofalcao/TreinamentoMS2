using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    interface IPagamento : IPagamentoInfo
    {
        double Valor { get; set; }
        void Pagar(double valor);
    }
}
