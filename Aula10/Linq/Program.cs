using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtos = new Produto[]
            {
                new Produto { Codigo = 1, Descricao = "Coca-Cola", Preco = 5.5 },
                new Produto { Codigo = 2, Descricao = "Pepsi", Preco = 5.0 },
                new Produto { Codigo = 3, Descricao = "Batata Frita", Preco = 30.0 },
                new Produto { Codigo = 4, Descricao = "Mandioca Frita", Preco = 30.0 },
                new Produto { Codigo = 5, Descricao = "Contra filé", Preco = 70.0 },
            };

            ////var produtosComPrecoMenorQue10 = produtos.Where(x => x.Preco < 10);
            var produtosComPrecoMenorQue10 = from x in produtos where x.Preco < 10 select x;

            //Imprimir("Produtos com preço menor que 10", produtosComPrecoMenorQue10);

            //var codigosDosProdutosComPrecoMenorQue10 = from x in produtos where x.Preco < 10 select x.Codigo;
            var codigosDosProdutosComPrecoMenorQue10 = produtos.Where(x => x.Preco < 10).Select(x => x.Codigo);


            Console.ReadKey();
        }

        private static void Imprimir(string mensagem, IEnumerable<Produto> produtos)
        {
            Console.WriteLine(mensagem + ":");

            foreach (var p in produtos)
                Console.WriteLine($"   {p.Descricao}, {p.Preco:C2}");

            Console.WriteLine();
        }

        class Produto
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; }
            public double Preco { get; set; }
        }
    }
}
