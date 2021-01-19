using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    public interface IPessoaAcao<T>
    {
        T ExecutarAcao(PessoaFisica obj);
        T ExecutarAcao(PessoaJuridica obj);
    }
}
