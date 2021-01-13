using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class Cliente : Entidade
    {
        public string Nome { get; set; }

        public override object Clone()
        {
            return new Cliente
            {
                Id = this.Id,
                Nome = this.Nome
            };
        }
    }
}
