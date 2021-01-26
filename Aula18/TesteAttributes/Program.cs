using System;
using System.Linq;
using System.Reflection;

namespace TesteAttributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new Cliente { Nome = "Ana", Email = "ana@email.com" };

            Imprimir(cli);

            Imprimir(new { Teste = "123", OQueEhIsso = 1, EhSerioIsso = true });

            var prod = new Produto { Codigo = 1, Descricao = "Coca-cola", Preco = 5.5 };

            Imprimir(prod);

            Console.ReadKey();
        }

        private static void Imprimir<T>(T obj)
        {
            var tipo = typeof(T);

            ImprimirTitulo(tipo);

            ImprimirPropriedades(tipo.GetProperties(), obj);
        }

        private static void ImprimirPropriedades(PropertyInfo[] propertyInfos, object obj)
        {
            foreach (var propInfo in propertyInfos)
            {
                var atributo = propInfo.GetCustomAttributes(typeof(TituloAttribute)).FirstOrDefault();

                if (atributo == null)
                    Console.Write($"  {propInfo.Name}: ");
                else
                    Console.Write($"  {((TituloAttribute)atributo).Titulo}: ");

                Console.WriteLine(propInfo.GetValue(obj));
            }
        }

        private static void ImprimirTitulo(Type tipo)
        {
            var atributosClasse = tipo.GetCustomAttributes(typeof(TituloAttribute), false);

            if (atributosClasse.Length > 0)
            {
                TituloAttribute atributo = (TituloAttribute)atributosClasse[0];

                Console.WriteLine($"{atributo.Titulo}:");
            }
            else
                Console.WriteLine($"{tipo.Name}:");
        }
    }
}
