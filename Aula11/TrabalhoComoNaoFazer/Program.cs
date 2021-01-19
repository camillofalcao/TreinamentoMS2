using System;

namespace TrabalhoComoNaoFazer
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoas = new Pessoa[]
            {
                new PessoaFisica { Nome = "Ana", Cpf = "123"},
                new PessoaJuridica { Nome = "Empresa 1", Cnpj = "111", Contato = "José da Silva" },
                new PessoaFisica { Nome = "Bruno", Cpf = "125"},
                new PessoaJuridica { Nome = "Empresa 2", Cnpj = "222", Contato = "Maria da Silva" },
                new PessoaFisica { Nome = "Carlos", Cpf = "127"}
            };

            ImprimirEtiquetas(pessoas);

            ImprimirCartaDeCobranca(pessoas);

            ImprimirNotaPromissoria(pessoas, 100);

            Console.ReadKey();
        }

        private static void ImprimirNotaPromissoria(Pessoa[] pessoas, double valor)
        {
            Console.WriteLine("Notas promissórias:");

            foreach (var p in pessoas)
                p.ImprimirNotaPromissoria(valor);

            Console.WriteLine("-------------------------------------------");
        }

        private static void ImprimirCartaDeCobranca(Pessoa[] pessoas)
        {
            Console.WriteLine("Cartas de cobrança:");
            
            foreach (var p in pessoas)
                p.ImprimirCartaDeCobranca();

            Console.WriteLine("-------------------------------------------");
        }

        private static void ImprimirEtiquetas(Pessoa[] pessoas)
        {
            Console.WriteLine("Etiquetas para correspondência:");
            
            foreach (var p in pessoas)
                p.ImprimirEtiqueta();
            
            Console.WriteLine("-------------------------------------------");
        }
    }
}
