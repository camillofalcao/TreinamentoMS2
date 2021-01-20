using System;
using System.Linq;
using System.Threading.Tasks;

namespace TestesDiversos
{
    class Program
    {
        //async static Task<int> Processar()
        //{
        //    int soma = 0;

        //    Console.WriteLine("Log 1.1");

        //    await Task.Run(() =>
        //    {
        //        for (int i = 0; i < 10000000; i++)
        //        {
        //            if (i % 7 == 0)
        //                soma += i;
        //        }
        //    });

        //    Console.WriteLine("Log 1.2");

        //    return soma;
        //}

        //async static Task BaixarArquivo(string url, string caminho)
        //{
        //    Console.WriteLine($"Baixando arquivo '{url}'...");

        //    await Task.Run(() =>
        //    {
        //        System.Threading.Thread.Sleep(2000);
        //        Console.WriteLine($"Arquivo '{url} baixado em '{caminho}'");
        //    });
        //}

        static void Main(string[] args)
        {
            var lista = Enumerable.Range(100, 10);

            Console.ReadKey();


            //var url = "http://exemplo.com/arquivo.zip";
            //var caminho = @"C:\Temp\caminho.zip";

            //Console.WriteLine("Programa iniciou o download...");

            //var tarefaBaixa = BaixarArquivo(url, caminho);

            //Console.WriteLine($"Baixando arquivo '{url}'...");

            //var tarefaBaixa = Task.Run(() =>
            //{
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine($"Arquivo '{url} baixado em '{caminho}'");
            //});

            //Console.WriteLine("Programa fez algo.");

            //Console.WriteLine("Programa fez outra coisa.");

            //Console.WriteLine("Agora o programa aguardará o término do download");

            //tarefaBaixa.Wait(5000);

            //Console.WriteLine("Fim do programa");

            //Console.ReadKey();

            //int soma;

            //Console.WriteLine("Log: 1");

            //var resultadoProcessamento = Processar();

            //Console.WriteLine("Log: 2");

            //resultadoProcessamento.Wait();

            //soma = resultadoProcessamento.Result;

            //Console.WriteLine($"Soma: {soma}");

            //Console.ReadKey();




            //var dataInicial = DateTime.Now;

            //Console.WriteLine("Tecle <Enter> o mais rápido possível");

            //Console.ReadKey();

            //var dataFinal = DateTime.Now;

            //TimeSpan intervaloDeTempo = (dataFinal - dataInicial);

            //Console.WriteLine($"Data inicial: {dataInicial.ToShortDateString()} {dataInicial.ToLongTimeString()}");
            //Console.WriteLine($"Data final: {dataFinal.ToShortDateString()} {dataFinal.ToLongTimeString()}");

            //Console.WriteLine($"Diferença em segundos: {intervaloDeTempo.TotalSeconds}");

            Console.ReadKey();
        }
    }
}
