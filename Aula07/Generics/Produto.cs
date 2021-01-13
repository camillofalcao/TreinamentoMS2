using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class Produto : Entidade
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public override object Clone()
        {
            return new Produto
            {
                Id = this.Id,
                Codigo = this.Codigo,
                Descricao = this.Descricao,
                Preco = this.Preco
            };
        }
    }
}
