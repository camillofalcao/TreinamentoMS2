using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao
{
    class Pagamento : IPagamentoInfo
    {
        public double ValorPago { get => valorPago; set => valorPago = value; }

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

        public DateTime DataPagamento { get => dataPagamento; set => dataPagamento = value; }

        private DateTime dataEmissao;
        private DateTime dataVencimento;
        private DateTime dataPagamento;
        private double valorPago;
    }
}
