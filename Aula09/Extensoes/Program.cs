using System;

namespace Extensoes
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Juiz de Fora";

            //Console.WriteLine(MeusMetodos.AdicionarAspas(texto));
            Console.WriteLine(texto.AdicionarAspas());

            //Console.WriteLine($"O caractere {texto[0]} {(MeusMetodos.EhVogal(texto[0]) ? "é uma vogal" : "não é uma vogal")}.");
            Console.WriteLine($"O caractere {texto[0]} {(texto[0].EhVogal() ? "é uma vogal" : "não é uma vogal")}.");

            //Console.WriteLine($"Existem {MeusMetodos.ContaVogais(texto)} vogais em '{texto}'.");
            Console.WriteLine($"Existem {texto.ContaVogais()} vogais em '{texto}'.");

            Console.WriteLine("Removendo a string 'Fora': " + texto.RemoverTexto("Fora"));

            var vet = new int[] { 1, 10, 5, 15, 12, 29, 30 };

            var numerosDivisiveisPor5 = vet.Selecionar(x => x % 5 == 0);

            Console.WriteLine("Números do vetor divisíveis por 5: ");

            foreach (var item in numerosDivisiveisPor5)
                Console.Write($"{item}  ");
            
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
