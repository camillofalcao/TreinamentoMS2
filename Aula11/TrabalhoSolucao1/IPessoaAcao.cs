using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao1
{
    interface IPessoaAcao
    {
        void ExecutarAcao(PessoaFisica obj);
        void ExecutarAcao(PessoaJuridica obj);
    }
}
