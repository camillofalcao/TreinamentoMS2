using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    class PessoaCartaCobrancaService : IPessoaAcao
    {
        public void Imprimir(IEnumerable<Pessoa> pessoas)
        {
            Console.WriteLine("Cartas de cobrança:");

            foreach (var p in pessoas)
                p.Executar(this);

            Console.WriteLine("------------------------------------------");
        }

        public void Imprimir(Pessoa pessoa)
        {
            Console.WriteLine("Carta de cobrança:");

            pessoa.Executar(this);

            Console.WriteLine("------------------------------------------");
        }

        public void ExecutarAcao(PessoaFisica obj)
        {
            Console.WriteLine($"Olá {obj.Nome}! Consta em nossa base que você nos deve!");
        }

        public void ExecutarAcao(PessoaJuridica obj)
        {
            Console.WriteLine($"Olá {obj.Contato}! Consta em nossa base que a empresa {obj.Nome} nos deve!");
        }
    }
}
