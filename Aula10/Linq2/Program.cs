using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            var pedidos = RetornarPedidos();

            var soma = pedidos.Sum(x => x.Total);
            var media = pedidos.Average(x => x.Total);
            var primeiro = pedidos.First();
            var ultimo = pedidos.Last();

            ImprimirPedidos("Lista de pedidos", pedidos);

            var pedidosAcima50 = from x in pedidos where x.Total > 50 select x;
            
            ImprimirPedidos("Lista de pedidos com preço acima de 50", pedidosAcima50);

            var pedidosPorCliente = from x in pedidos
                                    group x by x.Cliente into grupo
                                    select grupo;

            ImprimirAgrupado(pedidosPorCliente);

            var totalPorCliente =   from x in pedidos
                                    group new { Numero = x.Numero, Total = x.Total } 
                                    by x.Cliente.Nome 
                                    into grupo 
                                    select new { NomeCliente = grupo.Key, Total = grupo.Sum(x => x.Total) };

            Console.WriteLine("=====================================================");

            Console.WriteLine("Total por cliente:");

            foreach (var grupo in totalPorCliente)
                Console.WriteLine($"{grupo.NomeCliente}: {grupo.Total:C2}");
            
            Console.ReadKey();
        }

        private static void ImprimirAgrupado(IEnumerable<IGrouping<Cliente, Pedido>> pedidosAgrupados)
        {
            Console.WriteLine("Pedidos agrupados por cliente:");

            foreach (var grupo in pedidosAgrupados)
            {
                Console.WriteLine($"Grupo: {grupo.Key.Nome}");

                foreach (var pedido in grupo)
                {
                    Console.WriteLine($"Pedido: {pedido.Numero}, Valor Total: {pedido.Total:C2}");
                }
            }    
        }

        private static void ImprimirPedidos(string mensagem, IEnumerable<Pedido> pedidos)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine(mensagem + ":");
            
            foreach (var ped in pedidos)
            {
                Console.WriteLine("-----------------------------------------------------"); 
                Console.WriteLine($"Pedido: {ped.Numero}, Valor Total: {ped.Total:C2}, cliente: {ped.Cliente.Nome}");

                foreach (var item in ped.Itens)
                    Console.WriteLine($"   {item.Produto.Descricao}: {item.Quantidade} x {item.Produto.Preco:C2} = {item.SubTotal:C2}");
                
            }

            Console.WriteLine("=====================================================");
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
                         new PedidoItem { Produto = p3, Quantidade = 1 }
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
