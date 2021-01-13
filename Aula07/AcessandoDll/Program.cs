using Funcoes;
using System;

namespace AcessandoDll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"2 + 5 = {Inteiro.Somar(2, 5)}");
            Console.WriteLine($"2 - 5 = {Inteiro.Subtrair(2, 5)}");

            Console.WriteLine($"2,5 + 5 = {Real.Somar(2.5, 5)}");
            Console.WriteLine($"2,5 - 5 = {Real.Subtrair(2.5, 5)}");

            Console.ReadKey();
        }
    }
}
