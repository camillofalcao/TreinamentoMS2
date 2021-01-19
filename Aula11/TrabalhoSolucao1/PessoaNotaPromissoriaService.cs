using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    class PessoaNotaPromissoriaService : IPessoaAcao
    {
        public void Imprimir(IEnumerable<Pessoa> pessoas, double valor)
        {
            Console.WriteLine("Nota promissória:");

            this.valor = valor;

            foreach (var p in pessoas)
                p.Executar(this);

            Console.WriteLine("------------------------------------------");
        }

        public void ExecutarAcao(PessoaFisica obj)
        {
            Console.WriteLine($"Eu {obj.Nome} devo {valor:C2}");
        }

        public void ExecutarAcao(PessoaJuridica obj)
        {
            Console.WriteLine($"Eu {obj.Contato} na qualidade de representante da empresa {obj.Nome} devo {valor:C2}.");
        }

        private double valor;
    }
}
