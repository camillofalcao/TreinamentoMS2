using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    public class PessoaCartaCobrancaService
    {
        public void Imprimir(IEnumerable<Pessoa> pessoas)
        {
            Console.WriteLine("Cartas de cobrança:");

            foreach (var p in pessoas)
            {
                Console.WriteLine(p.Executar(acao));
            }

            Console.WriteLine("-----------------------------------------------------");
        }

        private PessoaCartaCobrancaAcao acao = new PessoaCartaCobrancaAcao();
    }
}
