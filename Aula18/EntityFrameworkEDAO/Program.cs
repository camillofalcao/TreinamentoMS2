using EntityFrameworkEDAO.DAL;
using EntityFrameworkEDAO.Models;
using System;
using System.Collections.Generic;

namespace EntityFrameworkEDAO
{
    class Program
    {
        static void Main(string[] args)
        {
            TestarProdutos();

            TestarClientes();

            TestarPedidos();

            Console.ReadKey();
        }

        private static void TestarPedidos()
        {
            var daoCliente = new ClienteDAO();
            var daoProduto = new ProdutoDAO();
            var daoPedido = new PedidoDAO();

            var cliente = daoCliente.RetornarPorId("1");
            var produto1 = daoProduto.RetornarPorId("1");
            var produto2 = daoProduto.RetornarPorId("2");

            var pedido = new Pedido
            {
                PedidoId = "1",
                Cliente = cliente,
                ClienteId = cliente.ClienteId,
                Numero = 1,
                Itens = new List<PedidoItem>
               {
                   new PedidoItem { PedidoId = "1", PedidoItemId = "1", Produto = produto1, Quantidade = 5},
               }
            };

            daoPedido.Inserir(pedido);

            pedido.Itens.Add(new PedidoItem { PedidoId = "1", PedidoItemId = "2", Produto = produto2, Quantidade = 3 });

            daoPedido.Alterar(pedido);

            pedido.Itens.RemoveAt(0);

            daoPedido.Alterar(pedido);

            pedido.Itens.Add(new PedidoItem { PedidoId = "1", PedidoItemId = "3", Produto = produto2, Quantidade = 4 });

            daoPedido.Alterar(pedido);

            ImprimirPedido();

            daoPedido.Excluir(pedido);
        }

        private static void ImprimirPedido()
        {
            var dao = new PedidoDAO();

            var pedido = dao.RetornarPorId("1");

            dao.CargaTardia(pedido);

            Console.WriteLine($"Pedido: {pedido.Numero}, cliente: {pedido.Cliente.Nome}:");

            foreach (var item in pedido.Itens)
                Console.WriteLine($"  Item: {item.Produto.Descricao} - {item.SubTotal:C2}");
        }

        private static void TestarClientes()
        {
            var dao = new ClienteDAO();

            dao.Inserir(new Cliente { ClienteId = "1", Nome = "José", Email = "jose@email.com" });
        }

        private static void TestarProdutos()
        {
            var dao = new ProdutoDAO();

            var obj = new Produto { ProdutoId = "1", Codigo = 1, Descricao = "Coca-Cola", Preco = 5.5 };

            dao.Inserir(obj);

            obj.Descricao = "Coca-Cola Lata";

            dao.Alterar(obj);

            dao.Inserir(new Produto { ProdutoId = "2", Descricao = "Pepsi", Codigo = 2, Preco = 5 });

            var listaProdutos = dao.RetornarTodos();

            foreach (var p in listaProdutos)
                Console.WriteLine($"{p.Codigo} - {p.Descricao} - {p.Preco:C2}");
        }
    }
}
