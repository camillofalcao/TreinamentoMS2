using CamadaAcessoADados.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CamadaAcessoADados.DAOs
{
    class ProdutoDAO
    {
        public void Inserir(Produto obj)
        {
            if (obj.ProdutoId == null)
                obj.ProdutoId = Guid.NewGuid().ToString();

            var sql = "INSERT INTO PRODUTO" +
                " (ID_PRODUTO,CODIGO,DESCRICAO,PRECO)" +
                " VALUES (@ID_PRODUTO,@CODIGO,@DESCRICAO,@PRECO)";

            ExecutarComando(sql, obj, AdicionarParametrosTodos);
        }

        public void Atualizar(Produto obj)
        {
            var sql = "UPDATE PRODUTO" +
                " SET CODIGO=@CODIGO,DESCRICAO=@DESCRICAO,PRECO=@PRECO" +
                " WHERE ID_PRODUTO=@ID_PRODUTO";

            ExecutarComando(sql, obj, AdicionarParametrosTodos);
        }

        public void Excluir(Produto obj)
        {
            var sql = "DELETE PRODUTO" +
                " WHERE ID_PRODUTO=@ID_PRODUTO";

            ExecutarComando(sql, obj, AdicionarParametroId);
        }

        public Produto RetornarPorId(string id)
        {
            var sql = "SELECT * FROM PRODUTO WHERE ID_PRODUTO = @ID_PRODUTO";
            
            var parametros = new SqlParameter[]
            {
                new SqlParameter("ID_PRODUTO", id)
            };

            var resultados = ExecutarConsulta(sql, parametros);

            if (resultados.Count == 0)
                return null;

            return resultados[0];
        }

        public IEnumerable<Produto> RetornarPorParteDescricao(string parteDescricao)
        {
            var sql = "SELECT * FROM PRODUTO WHERE DESCRICAO LIKE @DESCRICAO";

            var parametros = new SqlParameter[]
            {
                new SqlParameter("DESCRICAO", "%" + parteDescricao + "%")
            };

            return ExecutarConsulta(sql, parametros);
        }

        private IList<Produto> ExecutarConsulta(string sql, SqlParameter[] parametros)
        {
            using (var conexao = new SqlConnection(connString))
            {
                conexao.Open();

                var cmd = new SqlCommand(sql, conexao);

                cmd.Parameters.AddRange(parametros);

                var regs = new DataTable();

                var da = new SqlDataAdapter(cmd);

                da.Fill(regs);

                conexao.Close();

                return DeserializarTabela(regs);
            }
        }

        private IList<Produto> DeserializarTabela(DataTable regs)
        {
            var objetos = new List<Produto>();

            foreach (DataRow reg in regs.Rows)
                objetos.Add(DeserializarLinha(reg));
            
            return objetos;
        }

        private Produto DeserializarLinha(DataRow reg)
        {
            var obj = new Produto();
            
            obj.ProdutoId = reg["ID_PRODUTO"].ToString();
            obj.Codigo = Convert.ToInt32(reg["CODIGO"]);
            obj.Descricao = reg["DESCRICAO"].ToString();
            obj.Preco = Convert.ToDouble(reg["PRECO"]);
            
            return obj;
        }

        private void ExecutarComando(string sql, Produto obj, Action<SqlCommand,Produto> adicionarParametros)
        {
            using (var conexao = new SqlConnection(connString))
            {
                conexao.Open();

                var cmd = new SqlCommand(sql, conexao);

                adicionarParametros(cmd, obj);

                cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }

        private void AdicionarParametrosTodos(SqlCommand cmd, Produto obj)
        {
            cmd.Parameters.AddWithValue("ID_PRODUTO", obj.ProdutoId);
            cmd.Parameters.AddWithValue("CODIGO", obj.Codigo);
            cmd.Parameters.AddWithValue("DESCRICAO", obj.Descricao);
            cmd.Parameters.AddWithValue("PRECO", obj.Preco);
        }

        private void AdicionarParametroId(SqlCommand cmd, Produto obj)
        {
            cmd.Parameters.AddWithValue("ID_PRODUTO", obj.ProdutoId);
        }

        private const string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestesManager;Integrated Security=SSPI;";
    }
}
