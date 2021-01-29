using System;

namespace TesteStructs
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Ponto { X = 2.0, Y = 5.5 };
            var p2 = new Ponto { X = 4.0, Y = 7.0 };

            if (p1 == p2)
                Console.WriteLine("Mesmo ponto");
            else
                Console.WriteLine("Pontos diferentes");

            Imprimir("Ponto 1", p1);
            Imprimir("Ponto 2", p2);

            Console.WriteLine($"Distância: {p1.GetDistancia(p2)}");

            Console.WriteLine("Tecle <Enter> para finalizar");
            Console.ReadKey();
        }

        private static void Imprimir(string descricao, Ponto p)
        {
            Console.WriteLine($"{descricao}: x={p.X} y={p.Y}");
            p.X = p.X * 2;
        }
    }
}
