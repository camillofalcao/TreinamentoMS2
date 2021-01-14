using System;
using System.Collections;
using System.Collections.Generic;

namespace ActionFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto[] produtos = RetornarProdutos();
            Cliente[] clientes = RetornarClientes();

            //TestarActions(produtos);

            TestarFuncs(produtos, clientes);

            Console.ReadKey();
        }

        private static void TestarFuncs(Produto[] produtos, Cliente[] clientes)
        {
            var produtosIniciadosPorP = Selecionar(produtos, x => x.Descricao.StartsWith("P"));

            var produtosComPrecoMaiorQue10 = Selecionar(produtos, x => x.Preco > 10);

            var clientesComNomeTerminadoEmA = Selecionar(clientes, x => x.Nome.EndsWith("a") || x.Nome.EndsWith("A"));

            var vetor = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var pares = Selecionar<int>(vetor, x => x % 2 == 0);

            var impares = Selecionar(vetor, x => x % 2 != 0);

            Console.ReadKey();

            //Console.WriteLine("Produtos iniciados por 'P'");
            //Imprimir(produtos, prod => prod.Descricao.StartsWith('P'));

            //Console.WriteLine("Produtos com preço menor que 10");
            //Imprimir(produtos, x => x.Preco < 10);


            //Func<int, int, double> retornaMedia = (int num1, int num2) =>
            //{
            //    return (num1 + num2) / 2.0;
            //};

            //Console.WriteLine(retornaMedia(5, 10));
        }

        private static IEnumerable<T> Selecionar<T>(IEnumerable<T> objetos, Func<T, bool> selecionar)
        {
            var resultados = new List<T>();

            foreach (var obj in objetos)
                if (selecionar(obj))
                    resultados.Add(obj);

            return resultados;
        }

        private static void Imprimir(Produto[] produtos, Func<Produto, bool> selecionar)
        {
            foreach (var item in produtos)
            {
                if (selecionar(item))
                    Console.WriteLine($"{item.Descricao}, preço: {item.Preco:C2}");
            }
        }

        private static void TestarActions(Produto[] produtos)
        {
            Console.WriteLine("Produtos com preço > R$7,00:");

            ExecutarParaCada(produtos, ImprimirSePrecoMaiorQue7);
            //ExecutarParaCada(produtos, prod => 
            //{
            //    if (prod.Preco > 7)
            //        Console.WriteLine($"{prod.Descricao}, {prod.Preco:C2}");
            //});

            Console.WriteLine("Produtos com descrição iniciada por 'P'");

            ExecutarParaCada(produtos, prod =>
            {
                if (prod.Descricao.StartsWith("P"))
                    Console.WriteLine($"{prod.Descricao}");
            });

            int qtdeProdutos = 0;

            ExecutarParaCada(produtos, prod => qtdeProdutos++);

            Console.WriteLine($"Temos {qtdeProdutos} produtos.");

            ////Action<string, int> meuProcedimento = ImprimirOla;
            //Action<string, int> meuProcedimento = (string nome, int numeroVezes) =>
            //{
            //    for (int i = 0; i < numeroVezes; i++)
            //        Console.WriteLine($"Olá {nome}!");
            //};

            //meuProcedimento("João", 5);
            //Executar((string produto, int quantidade) =>
            //{
            //    Console.WriteLine($"Produto: {produto}, quantidade: {quantidade}");
            //});
        }

        private static void ImprimirSePrecoMaiorQue7(Produto prod)
        {
            if (prod.Preco > 7)
                Console.WriteLine($"{prod.Descricao}, {prod.Preco:C2}");
        }

        private static void ExecutarParaCada(Produto[] produtos, Action<Produto> metodoSelecao)
        {
            foreach (var item in produtos)
            {
                metodoSelecao(item);
            }
        }

        private static Cliente[] RetornarClientes()
        {
            return new Cliente[]
            {
                new Cliente { Nome = "Ana" },
                new Cliente { Nome = "Bruno" },
                new Cliente { Nome = "Carlos" },
                new Cliente { Nome = "Daniela" },
                new Cliente { Nome = "Evandro" }
            };
        }

        private static Produto[] RetornarProdutos()
        {
            return new Produto[]
            {
                new Produto { Codigo = 1, Descricao = "Coca-Cola", Preco = 5.5 },
                new Produto { Codigo = 2, Descricao = "Pizza A", Preco = 35.5 },
                new Produto { Codigo = 3, Descricao = "Pizza B", Preco = 45.5 },
                new Produto { Codigo = 4, Descricao = "Pastel A", Preco = 5 },
                new Produto { Codigo = 5, Descricao = "Batata Frita", Preco = 25 },
            };
        }

        //static void ImprimirOla(string nome, int numeroVezes)
        //{
        //    for (int i = 0; i < numeroVezes; i++)
        //        Console.WriteLine($"Olá {nome}!");
        //}

        //static void Executar(Action<string, int> procedimento)
        //{
        //    procedimento("Coca-cola", 10);
        //}
    }
}
