using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    public abstract class Pessoa
    {
        public string Nome { get; set; }

        public abstract T Executar<T>(IPessoaAcao<T> acao);
    }
}
