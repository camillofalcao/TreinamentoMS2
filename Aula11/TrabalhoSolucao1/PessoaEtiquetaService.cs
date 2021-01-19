using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    class PessoaEtiquetaService : IPessoaAcao
    {
        public void Imprimir(IEnumerable<Pessoa> pessoas)
        {
            Console.WriteLine("Etiquetas para correspondência:");

            foreach (var p in pessoas)
                p.Executar(this);

            Console.WriteLine("------------------------------------------");
        }

        public void ExecutarAcao(PessoaFisica obj)
        {
            Console.WriteLine($"Etiqueta: {obj.Nome}");
        }

        public void ExecutarAcao(PessoaJuridica obj)
        {
            Console.WriteLine($"Etiqueta: {obj.Nome}, aos cuidados de {obj.Contato}");
        }
    }
}
