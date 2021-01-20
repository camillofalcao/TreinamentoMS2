using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoAssincrona1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{ProcessamentoSincrono()} raízes inteiras (Síncrono)\n");

            Console.WriteLine($"{ProcessamentoAssincrono()} raízes inteiras (Parallel.For)\n");

            Console.WriteLine($"{ProcessamentoAssincronoUsandoTask()} raízes inteiras (Task)\n");

            Console.WriteLine($"{ProcessamentoAssincronoUsandoPLinq()} raízes inteiras (PLINQ)\n");

            Console.ReadKey();
        }

        private static int ProcessamentoSincrono()
        {
            var inicio = DateTime.Now;

            var cont = Processamento(0, MAX);

            Console.WriteLine($"Síncrono: {(DateTime.Now - inicio).TotalSeconds} segundos.");

            return cont;
        }

        private static int ProcessamentoAssincrono()
        {
            int div = MAX / NUMERO_THREADS;
            DateTime inicio = DateTime.Now;

            int[] resultados = new int[NUMERO_THREADS];
            int tot;

            Parallel.For(0, NUMERO_THREADS, i => resultados[i] = Processamento(i * div, (i + 1) * div));

            tot = resultados.Sum();

            Console.WriteLine($"Assíncrono: {(DateTime.Now - inicio).TotalSeconds} segundos.");

            return tot;
        }

        private static int ProcessamentoAssincronoUsandoTask()
        {
            var div = MAX / NUMERO_THREADS;
            var inicio = DateTime.Now;

            var resultados = new Task<int>[NUMERO_THREADS];

            int tot;

            for (int i = 0; i < NUMERO_THREADS; i++)
            {
                resultados[i] = ProcessamentoAsync(i * div, (i + 1) * div);
            }

            Task.WaitAll(resultados);

            tot = resultados.Sum(x => x.Result);

            Console.WriteLine($"Assíncrono com Task: {(DateTime.Now - inicio).TotalSeconds} segundos.");

            return tot;
        }

        private async static Task<int> ProcessamentoAsync(int inicio, int fim)
        {
            int cont = 0;
            double raiz;

            await Task.Run(() =>
            {
                for (int i = inicio; i < fim; i++)
                {
                    raiz = Math.Sqrt(i);
                    if (raiz == Math.Floor(raiz))
                        cont++;
                }
            });

            return cont;
        }

        private static int ProcessamentoAssincronoUsandoPLinq()
        {
            var inicio = DateTime.Now;
            var div = MAX / NUMERO_THREADS;

            int tot = Enumerable.Range(0, NUMERO_THREADS).AsParallel().Sum((index) => Processamento(index * div, (index + 1) * div));
            
            Console.WriteLine($"Assíncrono com PLinq: {(DateTime.Now - inicio).TotalSeconds} segundos.");

            return tot;
        }

        private static int Processamento(int inicio, int fim)
        {
            int cont = 0;
            double raiz;

            for (int i = inicio; i < fim; i++)
            {
                raiz = Math.Sqrt(i);
                if (raiz == Math.Floor(raiz))
                    cont++;
            }

            return cont;
        }

        private const int MAX = 1000000000;
        private const int NUMERO_THREADS = 10;
    }
}
