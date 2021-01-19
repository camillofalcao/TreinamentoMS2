using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    public class PessoaEtiquetaService
    {
        public void Imprimir(IEnumerable<Pessoa> pessoas)
        {
            Console.WriteLine("Etiquetas para correspondência:");

            foreach (var p in pessoas)
            {
                Console.WriteLine(p.Executar(acao));
            }

            Console.WriteLine("-----------------------------------------------------");
        }

        private PessoaEtiquetaAcao acao = new PessoaEtiquetaAcao();
    }
}
