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

        public void Pagar(double valor) 
        {
            if (DataPagamento.Year > 1)
                throw new Exception("Você está tentando pagar uma conta que já foi paga.");

            if (valor < ValorASerPago)
                throw new Exception("Valor insuficiente para pagar a conta.");

            ValorPago = valor;
            DataPagamento = DateTime.Now;
        }
    }
}
