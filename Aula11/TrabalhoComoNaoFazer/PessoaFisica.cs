using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoComoNaoFazer
{
    class PessoaFisica : Pessoa
    {
        public string Cpf { get; set; }

        public override void ImprimirCartaDeCobranca()
        {
            Console.WriteLine($"Olá {Nome}! Consta em nossa base que você nos deve!");
        }

        public override void ImprimirEtiqueta()
        {
            Console.WriteLine($"Etiqueta: {Nome}");
        }

        public override void ImprimirNotaPromissoria(double valor)
        {
            Console.WriteLine($"Eu {Nome} devo {valor:C2}");
        }
    }
}
