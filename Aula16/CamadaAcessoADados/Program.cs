using CamadaAcessoADados.DAOs;
using CamadaAcessoADados.Models;
using System;

namespace CamadaAcessoADados
{
    class Program
    {
        static void Main(string[] args)
        {
            //InserirProduto();

            //AlterarProduto();

            //ExcluirProduto();

            ListarProdutos();
        }

        private static void ListarProdutos()
        {
            string parteDescricao = "";
            Console.WriteLine($"Produtos que contém '{parteDescricao}' em sua descrição:");

            var dao = new ProdutoDAO();

            var produtos = dao.RetornarPorParteDescricao(parteDescricao);

            foreach (var prod in produtos)
                Console.WriteLine($"Código: {prod.Codigo}, descrição: {prod.Descricao}");
        }

        private static void ExcluirProduto()
        {
            Console.WriteLine("Excluindo o produto ABD...");

            var dao = new ProdutoDAO();

            var obj = dao.RetornarPorId("ABD");

            if (obj == null)
            {
                Console.WriteLine("Não existe produto de código ABD");
                return;
            }

            dao.Excluir(obj);

            Console.WriteLine("Produto ABD excluído!");
        }

        private static void AlterarProduto()
        {
            Console.WriteLine("Alterando o produto ABC...");

            var dao = new ProdutoDAO();

            var obj = dao.RetornarPorId("ABC");

            if (obj == null)
            {   
                Console.WriteLine("Não existe produto de código ABC");
                return;
            }

            obj.Descricao += " Lata";

            dao.Atualizar(obj);

            Console.WriteLine("Produto ABC alterado!");
        }

        private static void InserirProduto()
        {
            Console.WriteLine("Inserindo produto...");

            var obj = new Produto
            {
                Codigo = 4,
                Descricao = "Guaraná Antarctica",
                Preco = 5
            };

            var dao = new ProdutoDAO();

            dao.Inserir(obj);

            Console.WriteLine("Produto inserido com sucesso!");
        }
    }
}
