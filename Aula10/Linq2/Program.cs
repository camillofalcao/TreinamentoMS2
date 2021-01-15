using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static IEnumerable<Pedido> RetornarPedidos()
        {
            var c1 = new Cliente { Nome = "Ana" };
            var c2 = new Cliente { Nome = "Bruno" };

            var p1 = new Produto { Codigo = 1, Descricao = "Coca-Cola", Preco = 5.5 };
            var p2 = new Produto { Codigo = 2, Descricao = "Guaraná", Preco = 5.0 };
            var p3 = new Produto { Codigo = 3, Descricao = "Contra-Filé", Preco = 55.9 };

            return new List<Pedido>
            {
                new Pedido
                {
                     Numero = 1,
                     Cliente = c1,
                     Itens = new List<PedidoItem>
                     {
                         new PedidoItem { Produto = p1, Quantidade = 2 },
                         new PedidoItem { Produto = p2, Quantidade = 1 },
                         new PedidoItem { Produto = p1, Quantidade = 1 }
                     }
                },
                new Pedido
                {
                     Numero = 2,
                     Cliente = c2,
                     Itens = new List<PedidoItem>
                     {
                         new PedidoItem { Produto = p2, Quantidade = 10 },
                         new PedidoItem { Produto = p1, Quantidade = 10 }
                     }
                },
                new Pedido
                {
                     Numero = 3,
                     Cliente = c1,
                     Itens = new List<PedidoItem>
                     {
                         new PedidoItem { Produto = p1, Quantidade = 3 }
                     }
                },
            };
        }

        class Pedido
        {
            public int Numero { get; set; }
            public Cliente Cliente { get; set; }
            public IEnumerable<PedidoItem> Itens { get; set; }
            public double Total => Itens.Sum(x => x.SubTotal);
        }

        class PedidoItem
        {
            public double Quantidade { get; set; }
            public Produto Produto { get; set; }
            public double SubTotal => Quantidade * Produto.Preco;
        }

        class Produto
        {
            public int Codigo { get; set; }
            public string Descricao { get; set; }
            public double Preco { get; set; }
        }

        class Cliente
        {
            public string Nome { get; set; }
        }
    }
}
