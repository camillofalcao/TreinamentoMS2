using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoComoNaoFazer
{
    abstract class Pessoa
    {
        public string Nome { get; set; }

        public abstract void ImprimirEtiqueta();
        public abstract void ImprimirCartaDeCobranca();
        public abstract void ImprimirNotaPromissoria(double valor);
    }
}
