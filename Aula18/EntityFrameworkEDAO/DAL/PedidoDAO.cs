using EntityFrameworkEDAO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkEDAO.DAL
{
    class PedidoDAO
    {
        public void Inserir(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                //Adiciona o objeto Pedido no contexto e todos os objetos do contexto como Unchanged (não modificados) e, em seguida, seta o estado da entidade Pedido para Added.
                contexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Altera para Added todos os itens de pedido monitorados
                foreach (var item in obj.Itens)
                    contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                contexto.SaveChanges();
            }
        }

        public void Alterar(Pedido obj)
        {   
            using (var contexto = new PedidosContext())
            {
                //Recupera todos os itens gravados na base
                var itensAnteriores = contexto.PedidoItens.Where(x => x.PedidoId == obj.PedidoId).ToList();

                //Para cada item que quero gravar
                foreach (var item in obj.Itens)
                {
                    //Se o item existir na base, pego o mesmo
                    var itemMonitorado = itensAnteriores.Where(x => x.PedidoItemId == item.PedidoItemId).FirstOrDefault();

                    //Se o item existe na base
                    if (itemMonitorado != null)
                    {
                        //Removo a entidade do monitoramento
                        contexto.Entry(itemMonitorado).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        //Adiciono o item identificando-o como modificado
                        contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        //Removo o item da lista de itens já gravados
                        itensAnteriores.Remove(itemMonitorado);
                    }
                    else
                    {
                        //Adiciono o item que nunca foi gravado com o State Added
                        contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    }
                }

                //Se sobrou item nessa lista, o mesmo foi deletado pelo usuário, logo altero o status dele para Deleted
                foreach (var item in itensAnteriores)
                    contexto.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                //Por fim adiciono a Entidate Pedido
                contexto.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                contexto.SaveChanges();
            }
        }

        public void Excluir(Pedido obj)
        {
            using (var contexto = new PedidosContext())
            {
                //Recupera todos os itens gravados na base
                var itensAnteriores = contexto.PedidoItens.Where(x => x.PedidoId == obj.PedidoId).ToList();

                //Altera o State de cada item para Deleted
                foreach (var item in itensAnteriores)
                    contexto.Entry(item).State = EntityState.Deleted;
                
                //Altera o state do pedido para Deleted
                contexto.Entry(obj).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Pedido> RetornarTodos()
        {
            IList<Pedido> retorno;

            using (var contexto = new PedidosContext())
                retorno = contexto.Pedidos.ToList();
            
            return retorno;
        }

        public Pedido RetornarPorId(string id)
        {
            Pedido produto;

            using (var contexto = new PedidosContext())
            {
                produto = contexto.Pedidos.Where(x => x.PedidoId == id).FirstOrDefault();
            }

            return produto;
        }

        public void CargaTardia(Pedido pedido)
        {
            using (var contexto = new PedidosContext())
            {
                pedido.Cliente = contexto.Clientes.Where(x => x.ClienteId == pedido.ClienteId).FirstOrDefault();
                pedido.Itens = contexto.PedidoItens.Where(x => x.PedidoId == pedido.PedidoId).ToList();

                foreach (var item in pedido.Itens)
                    item.Produto = contexto.Produtos.Where(x => x.ProdutoId == item.ProdutoId).FirstOrDefault();
            }
        }
    }
}
