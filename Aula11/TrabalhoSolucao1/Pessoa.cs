using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    abstract class Pessoa
    {
        public string Nome { get; set; }

        public abstract void Executar(IPessoaAcao acao);
    }
}
