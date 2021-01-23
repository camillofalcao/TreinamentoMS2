using System;
using System.Data;
using System.Data.SqlClient;

namespace UsandoAdoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conexao = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=TestesManager;Integrated Security=SSPI;"))
            {
                conexao.Open();

                var sql = "INSERT INTO PRODUTO (ID_PRODUTO, CODIGO, DESCRICAO, PRECO) VALUES (@ID_PRODUTO, @CODIGO, @DESCRICAO, @PRECO)";
                var cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("ID_PRODUTO", "ABG");
                cmd.Parameters.AddWithValue("CODIGO", 5);
                cmd.Parameters.AddWithValue("DESCRICAO", "Contra-filé");
                cmd.Parameters.AddWithValue("PRECO", 75.5);
                cmd.ExecuteNonQuery();
                
                /*
                var cmd = new SqlCommand("SELECT * FROM PRODUTO", conexao);

                var ds = new DataSet();
                
                var da = new SqlDataAdapter(cmd);

                da.Fill(ds);

                conexao.Close();

                foreach (DataRow reg in ds.Tables[0].Rows)
                {
                    Console.Write($"{reg["CODIGO"]}, ");
                    Console.WriteLine($"{reg["DESCRICAO"]}, {reg["PRECO"]:C2}");
                }
                */

                /*
                Console.Write("Informe parte da descrição do produto desejado: ");
                var parteDescricao = Console.ReadLine();

                //var sql = $"SELECT * FROM PRODUTO WHERE DESCRICAO LIKE '%{parteDescricao}%'";
                var sql = $"SELECT * FROM PRODUTO WHERE DESCRICAO LIKE @TEXTO_LIKE";
                var cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("TEXTO_LIKE", "%" + parteDescricao + "%");

                var dt = new DataTable();

                var da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                foreach (DataRow reg in dt.Rows)
                {
                    Console.Write($"{reg["CODIGO"]}, ");
                    Console.WriteLine($"{reg["DESCRICAO"]}, {reg["PRECO"]:C2}");
                }
                */
            }

            Console.WriteLine("Tecle <Enter> para sair.");
            Console.ReadKey();
        }
    }
}
