using System;

namespace Reflection2
{
    class Program
    {
        static void Main(string[] args)
        {
            var objeto1 = new Produto { Codigo = 1, Descricao = "Coca-Cola", Preco = 5.5 };

            //var tipo = objeto1.GetType();
            var tipo = typeof(Produto);

            var prop = tipo.GetProperty("Descricao");

            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto1)}");

            prop.SetValue(objeto1, "Coca-Cola 1L");

            Console.WriteLine($"{prop.Name}: {prop.GetValue(objeto1)}");

            Console.WriteLine($"Nova descrição: {objeto1.Descricao}");

            Console.WriteLine($"Linha CSV: {RetornarLinhaCsv(objeto1, "Descricao;Codigo")}");

            var metodo = tipo.GetMethod("TornarDescricaoMaiuscula");

            metodo.Invoke(objeto1, null);

            Console.WriteLine($"Descrição após chamar o método: {objeto1.Descricao}");

            Console.ReadKey();
        }

        private static string RetornarLinhaCsv<T>(T objeto, string camposSeparadosPorPontoEVirgula)
        {
            var retorno = "";
            var nomesPropriedades = camposSeparadosPorPontoEVirgula.Split(';');
            var separador = "";
            var tipo = typeof(T);

            foreach (var nomeProp in nomesPropriedades)
            {
                var prop = tipo.GetProperty(nomeProp);

                if (prop != null)
                {
                    retorno += separador + prop.GetValue(objeto);
                    separador = ";";
                }
            }

            return retorno;
        }
    }
}
