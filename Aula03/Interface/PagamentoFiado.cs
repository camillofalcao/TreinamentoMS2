using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    class PagamentoFiado : IPagamento
    {
        public DateTime DataEmissao
        {
            get => dataEmissao;
            set
            {
                if (dataVencimento.Year > 1 && value > dataVencimento)
                    throw new Exception("Data de emissão maior que a data de vencimento.");

                dataEmissao = value;
            }
        }

        public DateTime DataVencimento
        {
            get => dataVencimento;
            set
            {
                if (dataEmissao.Year > 1 && value < dataEmissao)
                    throw new Exception("Data de vencimento menor que a data de emissão.");

                dataVencimento = value;
            }
        }

        public DateTime DataPagamento
        {
            get => dataPagamento;
            set => dataPagamento = value;
        }

        public double ValorPago { get => valorPago; set => valorPago = value; }

        public PagamentoFiadoConsumo[] Consumos { get; set; }

        public double ValorASerPago
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

        public void Pagar(double valor)
        {
            if (DataPagamento.Year > 1)
                throw new Exception("Você está tentando pagar uma conta que já foi paga.");

            if (valor < ValorASerPago)
                throw new Exception("Valor insuficiente para pagar a conta.");

            ValorPago = valor;
            DataPagamento = DateTime.Now;
        }

        private DateTime dataVencimento;
        private DateTime dataPagamento;
        private DateTime dataEmissao;
        private double valorPago;
    }
}
