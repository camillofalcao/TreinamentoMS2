using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    class PagamentoFiado : IPagamento
    {
        public PagamentoFiado()
        {
            pagamentoInfo = new Pagamento();
        }

        public PagamentoFiadoConsumo[] Consumos { get; set; }

        public double Valor
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
        
        public DateTime DataEmissao { get => pagamentoInfo.DataEmissao; set => pagamentoInfo.DataEmissao = value; }
        public DateTime DataVencimento { get => pagamentoInfo.DataVencimento; set => pagamentoInfo.DataVencimento = value; }
        public DateTime DataPagamento { get => pagamentoInfo.DataPagamento; set => pagamentoInfo.DataPagamento = value; }
        public double ValorPago { get => pagamentoInfo.ValorPago; set => pagamentoInfo.ValorPago = value; }
        
        public void Pagar(double valor)
        {
            if (DataPagamento.Year > 1)
                throw new Exception("Você está tentando pagar uma conta que já foi paga.");

            if (valor < Valor)
                throw new Exception("Valor insuficiente para pagar a conta.");

            ValorPago = valor;
            DataPagamento = DateTime.Now;
        }

        private double valor;
        private IPagamentoInfo pagamentoInfo;
    }
}
