using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    public class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string Contato { get; set; }

        public override T Executar<T>(IPessoaAcao<T> acao) => acao.ExecutarAcao(this);
    }
}
