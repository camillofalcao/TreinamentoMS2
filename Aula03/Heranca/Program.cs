﻿using System;

/*
PagamentoBoleto
    DataVencimento
    DataPagamento
    Valor
    ValorPago
    LinhaDigitavel

PagamentoFiado
    DataVencimento
    DataPagamento
    Lista de Consumo
        Cada consumo possui uma descrição, uma quantidade, um valor unitário e um valor total
    Valor (soma do consumo)
    ValorPago
*/
namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            var pagamentos = RetornarPagamentos();
            Imprimir(pagamentos);
            Console.ReadKey();
        }

        private static void Imprimir(IPagamento[] pagamentos)
        {
            foreach (var item in pagamentos)
            {
                Console.WriteLine($"Pagamento: {item.ValorASerPago:C2} em {item.DataVencimento.ToShortDateString()}");
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
                    Valor = 123.45
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
