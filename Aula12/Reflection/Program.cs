using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var produto1 = new Produto { Codigo = 1, Descricao = "Coca-Cola", Preco = 5.5 };
            var produto2 = new Produto { Codigo = 2, Descricao = "Pepsi", Preco = 5.0 };
            var produto3 = new Produto { Codigo = 3, Descricao = "Pizza", Preco = 45.5 };

            Console.WriteLine($"Produto: {RetornarLinhaCsv(produto1)}");

            var cliente1 = new Cliente { Nome = "Ana", Email = "ana@email.com" };
            var cliente2 = new Cliente { Nome = "Bruno", Email = "bruno@email.com" };

            Console.WriteLine($"Cliente: {RetornarLinhaCsv(cliente1)}");

            var produtos = new Produto[] { produto1, produto2, produto3 };

            ExportarParaCsv(produtos);

            var clientes = new Cliente[] { cliente1, cliente2 };

            ExportarParaCsv(clientes);

            //ImprimirTipo(produto);

            //ImprimirTipo("Teste");

            //ImprimirTipo(200);

            /*
            if (typeof(int) == idade.GetType())
                Console.WriteLine("A variável 'idade' é do tipo 'int'.");
            else
                Console.WriteLine("A variável 'idade' NÃO é do tipo 'int'.");
            */

            Console.ReadKey();
        }

        private static void ExportarParaCsv<T>(IEnumerable<T> objetos)
        {
            Console.WriteLine("Exportando...");

            var sb = new StringBuilder();
            var tipo = typeof(T);

            var caminho = @$"D:\Camillo\Github\TreinamentoMS2\Aula12\{tipo.Name}s.csv";

            sb.Append(RetornarCabecalho(tipo) + "\n");

            foreach (var obj in objetos)
                sb.Append(RetornarLinhaCsv(obj) + "\n");

            File.WriteAllText(caminho, sb.ToString());

            Console.WriteLine($"Dados exportados em : {caminho}");
        }

        private static string RetornarCabecalho(Type tipo)
        {
            var retorno = "";
            var separador = "";

            foreach (var prop in tipo.GetProperties())
            {
                retorno += separador + prop.Name;
                separador = ";";
            }

            return retorno;
        }

        private static string RetornarLinhaCsv<T>(T objeto)
        {
            var retorno = "";
            var tipo = typeof(T);
            var separador = "";

            foreach (var prop in tipo.GetProperties())
            {
                retorno += separador + prop.GetValue(objeto);
                separador = ";";
            }

            return retorno;
        }

        private static void ImprimirTipo<T>(T obj)
        {
            //var tipo = obj.GetType();
            var tipo = typeof(T);

            Console.WriteLine($"Tipo: {tipo.FullName}");

            var propriedades = tipo.GetProperties();

            foreach (var prop in propriedades)
            {
                try
                {
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(obj)}");
                } catch { }
            }

            Console.WriteLine("------------------------------------------");
        }
    }
}
