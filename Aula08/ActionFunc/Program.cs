using System;

namespace ActionFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            //Action<string, int> meuProcedimento = ImprimirOla;
            Action<string, int> meuProcedimento = (string nome, int numeroVezes) =>
            {
                for (int i = 0; i < numeroVezes; i++)
                    Console.WriteLine($"Olá {nome}!");
            };

            meuProcedimento("João", 5);

            Console.ReadKey();
        }

        static void ImprimirOla(string nome, int numeroVezes)
        {
            for (int i = 0; i < numeroVezes; i++)
                Console.WriteLine($"Olá {nome}!");
        }
}
}
