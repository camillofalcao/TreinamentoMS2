using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string Contato { get; set; }

        public override void Executar(IPessoaAcao acao) => acao.ExecutarAcao(this);
    }
}
