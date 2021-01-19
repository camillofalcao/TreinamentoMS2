using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    internal class PessoaCartaCobrancaAcao : IPessoaAcao<string>
    {
        public string ExecutarAcao(PessoaFisica obj)
        {
            return $"Olá {obj.Nome}! Consta em nossa base que você nos deve!";
        }

        public string ExecutarAcao(PessoaJuridica obj)
        {
            return $"Olá {obj.Contato}! Consta em nossa base que a empresa {obj.Nome} nos deve!";
        }
    }
}
