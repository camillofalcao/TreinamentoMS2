using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    interface IPagamento : IPagamentoInfo
    {
        double Valor { get; }
        void Pagar(double valor);
    }
}
