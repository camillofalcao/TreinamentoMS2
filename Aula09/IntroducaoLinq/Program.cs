using System;
using System.Collections.Generic;
using System.Linq;
//using Extensoes;

namespace IntroducaoLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var numeros = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Imprimir("Números", numeros);

            //var numerosMaiorQue4 = numeros.Selecionar(x => x > 4);
            //var numerosMaiorQue4 = numeros.Where(x => x > 4);
            var numerosMaiorQue4 = from x in numeros where x > 4 select x;

            Imprimir("Números maiores que 4", numerosMaiorQue4);

            Console.WriteLine($"Soma dos números maiores que 4: {numerosMaiorQue4.Sum()}");

            //var numerosAoQuadrado = numeros.Transformar(x => x * x);
            //var numerosAoQuadrado = numeros.Select(x => x * x);
            var numerosAoQuadrado = from x in numeros select x * x;

            Imprimir("Números ao quadrado", numerosAoQuadrado);

            //var numerosMaioresQue4AoQuadrado = numeros.Selecionar(x => x > 4).Transformar(x => x * x);
            //var numerosMaioresQue4AoQuadrado = numeros.Where(x => x > 4).Select(x => x * x);
            var numerosMaioresQue4AoQuadrado = from x in numeros where x > 4 select x * x;

            Imprimir("Números maiores que 4 ao quadrado", numerosMaioresQue4AoQuadrado);

            var paresOuImpares = numeros.Select(x => (x % 2 == 0 ? $"{x} é par" : $"{x} é ímpar"));

            foreach (var item in paresOuImpares)
                Console.WriteLine(item);

            Console.ReadKey();
        }

        private static void Imprimir(string textoInicial, IEnumerable<int> numerosMaiorQue4)
        {
            Console.WriteLine(textoInicial);

            foreach(var num in numerosMaiorQue4)
                Console.Write($"{num}  ");

            Console.WriteLine();
        }
    }
}
