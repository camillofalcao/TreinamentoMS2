using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    public class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }

        public override T Executar<T>(IPessoaAcao<T> acao) => acao.ExecutarAcao(this);
    }
}
