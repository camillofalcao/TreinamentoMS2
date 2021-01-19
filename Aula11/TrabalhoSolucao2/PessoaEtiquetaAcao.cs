using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoSolucao2
{
    internal class PessoaEtiquetaAcao : IPessoaAcao<string>
    {
        public string ExecutarAcao(PessoaFisica obj)
        {
            return $"Etiqueta: {obj.Nome}";
        }

        public string ExecutarAcao(PessoaJuridica obj)
        {
            return $"Etiqueta: {obj.Nome}, aos cuidados de {obj.Contato}";
        }
    }
}
