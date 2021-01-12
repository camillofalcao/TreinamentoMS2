using System;
using System.Collections.Generic;

namespace Dicionario
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };
            var p2 = new Produto { Codigo = 2, Descricao = "Pepsi", Preco = 5.0 };
            var p3 = new Produto { Codigo = 3, Descricao = "Sprite", Preco = 5.0 };

            var dictProdutos = new Dictionary<int, Produto>();
            
            dictProdutos.Add(p1.Codigo, p1);
            dictProdutos.Add(p2.Codigo, p2);
            dictProdutos.Add(p3.Codigo, p3);

            Console.Write("Informe o código do produto desejado: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            if (dictProdutos.ContainsKey(codigo))
            {
                var produtoEncontrado = dictProdutos[codigo];

                Imprimir(produtoEncontrado);
            }
            else
            {
                Console.WriteLine($"Não existe o código {codigo} no sistema.");
            }

            Console.ReadKey();

        }

        private static Produto RetornaDaLista(List<Produto> listaProdutos, int codigo)
        {
            foreach (var item in listaProdutos)
            {
                if (item.Codigo == codigo)
                    return item;
            }

            return null;
        }

        private static void Imprimir(Produto produto)
        {
            Console.WriteLine($"{produto.Codigo} - {produto.Descricao}: {produto.Preco:C2}");
        }
    }
}
