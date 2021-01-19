using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }

        public override void Executar(IPessoaAcao acao) => acao.ExecutarAcao(this);
    }
}
