using System;

namespace ActionFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto[] produtos = RetornarProdutos();

            Console.WriteLine("Produtos com preço > R$7,00:");

            ExecutarParaCada(produtos, prod => 
            {
                if (prod.Preco > 7)
                {
                    Console.WriteLine($"{prod.Descricao}, {prod.Preco:C2}");
                }
            });

            Console.WriteLine("Produtos com descrição iniciada por 'P'");

            ExecutarParaCada(produtos, prod =>
            {
                if (prod.Descricao.StartsWith("P"))
                    Console.WriteLine($"{prod.Descricao}");
            });

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

            Console.ReadKey();
        }

        private static void ExecutarParaCada(Produto[] produtos, Action<Produto> metodoSelecao)
        {
            foreach (var item in produtos)
            {
                metodoSelecao(item);
            }
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
