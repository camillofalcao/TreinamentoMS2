using System;
using System.Collections.Generic;

namespace Colecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            //var idades = new int[5];
            //idades[0] = 20;

            //Lista
            var idades = new List<int>();
            idades.Add(20);
            idades.Add(25);
            idades.Add(50);
            idades.Add(55);

            Console.WriteLine($"Tamanho da lista: {idades.Count}");

            Imprimir(idades);

            if (idades.Contains(20))
                Console.WriteLine("A idade 20 está presente.");

            Console.ReadKey();
        }

        private static void Imprimir(List<int> idades)
        {
            Console.WriteLine("Idades informadas: ");

            for (int i = 0; i < idades.Count; i++)
                Console.Write($"{idades[i]}  ");
            
            Console.WriteLine();
        }
    }
}
