using EntityFrameworkEDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkEDAO.DAL
{
    class ProdutoDAO
    {
        public void Inserir(Produto obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Add(obj);
                contexto.SaveChanges();
            }
        }

        public void Alterar(Produto obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Update(obj);
                contexto.SaveChanges();
            }
        }

        public void Excluir(Produto obj)
        {
            using (var contexto = new PedidosContext())
            {
                contexto.Remove(obj);
                contexto.SaveChanges();
            }
        }

        public IList<Produto> RetornarTodos()
        {
            IList<Produto> retorno;

            using (var contexto = new PedidosContext())
            {
                retorno = contexto.Produtos.ToList();
            }

            return retorno;
        }

        public Produto RetornarPorId(string id)
        {
            Produto produto;

            using (var contexto = new PedidosContext())
            {
                produto = contexto.Produtos.Where(x => x.ProdutoId == id).FirstOrDefault();
            }

            return produto;
        }
    }
}
