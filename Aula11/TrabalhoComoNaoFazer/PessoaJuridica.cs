using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoComoNaoFazer
{
    class PessoaJuridica : Pessoa
    {
        public string Cnpj { get; set; }
        public string Contato { get; set; }

        public override void ImprimirCartaDeCobranca()
        {
            Console.WriteLine($"Olá {Contato}! Consta em nossa base que a empresa {Nome} nos deve!");
        }

        public override void ImprimirEtiqueta()
        {
            Console.WriteLine($"Etiqueta: {Nome}, aos cuidados de {Contato}");
        }

        public override void ImprimirNotaPromissoria(double valor)
        {
            Console.WriteLine($"Eu {Contato} na qualidade de representante da empresa {Nome} devo {valor:C2}.");
        }
    }
}
