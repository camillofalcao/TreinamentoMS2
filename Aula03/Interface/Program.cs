using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            var pagamentos = RetornarPagamentos();
            
            Imprimir(pagamentos);

            Console.WriteLine("Pagando tudo...");

            foreach (var item in pagamentos)
                item.Pagar(1000);
            
            Imprimir(pagamentos);

            Console.ReadKey();
        }

        private static void Imprimir(IPagamento[] pagamentos)
        {
            foreach (var item in pagamentos)
            {
                Console.Write($"Pagamento: {item.ValorASerPago:C2} em {item.DataVencimento.ToShortDateString()}");
                Console.WriteLine($", data pagamento: {item.DataPagamento.ToShortDateString()}, valor pago: {item.ValorPago:C2}");
            }
        }

        private static IPagamento[] RetornarPagamentos()
        {
            var hoje = DateTime.Now.Date;

            return new IPagamento[]
            {
                new PagamentoBoleto
                {
                    DataVencimento = hoje.AddDays(10),
                    LinhaDigitavel = "123",
                    ValorASerPago = 123.45
                },
                new PagamentoFiado
                {
                    DataVencimento = hoje.AddDays(30),
                    Consumos = new PagamentoFiadoConsumo[]
                    {
                        new PagamentoFiadoConsumo
                        {
                            Descricao = "Coca-cola",
                            Quantidade = 2,
                            ValorUnitario = 5.5
                        },
                        new PagamentoFiadoConsumo
                        {
                            Descricao = "Pepsi",
                            Quantidade = 3,
                            ValorUnitario = 5
                        }
                    }
                }
            };
        }
    }
}
