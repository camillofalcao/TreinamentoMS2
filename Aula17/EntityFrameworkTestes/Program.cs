using EntityFrameworkTestes.DAL;
using EntityFrameworkTestes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkTestes
{
    class Program
    {
        static void Main(string[] args)
        {
            //IncluirProdutos();
            //AlterarProduto();
            //ExcluirProduto();
            //ImprimirComPrecoMaiorQue(3);
            //AdicionarRegistros();
            ImprimirPedidos();

            Console.WriteLine("Fim do programa.");
            Console.ReadKey();
        }

        private static void ImprimirPedidos()
        {
            using (var db = new PedidosContext())
            {
                var pedidos = db.Pedidos.Include(a => a.Cliente).Include(y => y.Itens).ThenInclude(b => b.Produto);

                foreach (var p in pedidos)
                {
                    Console.WriteLine($"{p.Numero} - {p.Cliente.Nome}");

                    foreach (var item in p.Itens)
                    {   
                        Console.WriteLine($"    {item.Produto.Descricao,20} -> {item.Quantidade,8} x {item.Produto.Preco:C2} = {item.SubTotal:C2}");
                    }

                    Console.WriteLine($"Total do pedido {p.Numero}: {p.Total:C2}");
                }
            }
        }

        private static void AdicionarRegistros()
        {
            using (var db = new PedidosContext())
            {
                var c1 = new Cliente { ClienteId = "Cliente1", Nome = "Cliente 1", Email = "cliente1@email.com" };
                var c2 = new Cliente { ClienteId = "Cliente2", Nome = "Cliente 2", Email = "cliente2@email.com" };

                db.Clientes.AddRange(c1, c2);
                db.SaveChanges();

                var p1 = new Pedido
                {
                    PedidoId = "Pedido1",
                    Numero = 1,
                    Cliente = c1,
                    Itens = new List<PedidoItem>
                    {
                        new PedidoItem { PedidoItemId = "PedidoItem1", PedidoId = "Pedido1", Produto = RetornaProdutoPorId(db, "Produto1"), Quantidade = 5},
                        new PedidoItem { PedidoItemId = "PedidoItem2", PedidoId = "Pedido1", Produto = RetornaProdutoPorId(db, "Produto4"), Quantidade = 4}
                    }
                };

                var p2 = new Pedido
                {
                    PedidoId = "Pedido2",
                    Numero = 2,
                    Cliente = c2,
                    Itens = new List<PedidoItem>
                    {
                        new PedidoItem { PedidoItemId = "PedidoItem3", PedidoId = "Pedido2", Produto = RetornaProdutoPorId(db, "Produto3"), Quantidade = 3},
                        new PedidoItem { PedidoItemId = "PedidoItem4", PedidoId = "Pedido2", Produto = RetornaProdutoPorId(db, "Produto4"), Quantidade = 2},
                        new PedidoItem { PedidoItemId = "PedidoItem5", PedidoId = "Pedido2", Produto = RetornaProdutoPorId(db, "Produto5"), Quantidade = 1}
                    }
                };

                db.Pedidos.AddRange(p1, p2);
                db.SaveChanges();
            }
        }

        static Produto RetornaProdutoPorId(PedidosContext db, string id)
        {
            return db.Produtos.Where(x => x.ProdutoId == id).FirstOrDefault();
        }

        private static void ImprimirComPrecoMaiorQue(double preco)
        {
            using (var db = new PedidosContext())
            {
                //var produtos = db.Produtos.Where(x => x.Preco > preco);
                var produtos = from x in db.Produtos where x.Preco > preco select x;

                foreach (var p in produtos)
                    Console.WriteLine($"{p.Codigo} - {p.Descricao} - {p.Preco:C2}");
            }
        }

        private static void ExcluirProduto()
        {
            using (var db = new PedidosContext())
            {
                var p2 = (from x in db.Produtos where x.ProdutoId == "Produto2" select x).FirstOrDefault();

                if (p2 == null)
                    Console.WriteLine("Produto de id='Produto2' não encontrado.");
                else
                {
                    db.Produtos.Remove(p2);
                    db.SaveChanges();
                }
            }
        }

        private static void AlterarProduto()
        {
            using (var db = new PedidosContext())
            {
                //var p2 = db.Produtos.Where(x => x.ProdutoId == "Produto2").FirstOrDefault();
                var p2 = (from x in db.Produtos where x.ProdutoId == "Produto2" select x).FirstOrDefault();

                p2.Descricao = "Produto 2 (Alterado)";

                db.SaveChanges();
            }
        }

        private static void IncluirProdutos()
        {
            using (var db = new PedidosContext())
            {
                var p1 = new Produto { ProdutoId = "Produto1", Codigo = 1, Descricao = "Produto 1", Preco = 1.11 };
                var p2 = new Produto { ProdutoId = "Produto2", Codigo = 2, Descricao = "Produto 2", Preco = 2.22 };
                var p3 = new Produto { ProdutoId = "Produto3", Codigo = 3, Descricao = "Produto 3", Preco = 3.33 };
                var p4 = new Produto { ProdutoId = "Produto4", Codigo = 4, Descricao = "Produto 4", Preco = 4.44 };
                var p5 = new Produto { ProdutoId = "Produto5", Codigo = 5, Descricao = "Produto 5", Preco = 5.55 };

                db.Produtos.Add(p1);
                db.SaveChanges();

                db.Add(p2);
                db.SaveChanges();

                db.Add(p3);
                db.SaveChanges();

                db.Add(p4);
                db.SaveChanges();
                
                db.Add(p5);
                db.SaveChanges();
            }
        }

    }
}
