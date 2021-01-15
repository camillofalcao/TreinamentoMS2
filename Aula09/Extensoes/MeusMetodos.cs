using System;
using System.Collections.Generic;
using System.Text;

namespace Extensoes
{
    public static class MeusMetodos
    {
        public static IEnumerable<TRetorno> Transformar<TOrigem, TRetorno>(this IEnumerable<TOrigem> objetos, Func<TOrigem, TRetorno> transformar)
        {
            var listaRetorno = new List<TRetorno>();

            foreach (var item in objetos)
                listaRetorno.Add(transformar(item));
            
            return listaRetorno;
        }

        public static int Soma(this IEnumerable<int> numeros)
        {
            var soma = 0;

            foreach (var num in numeros)
                soma += num;

            return soma;
        }

        public static IEnumerable<T> Selecionar<T>(this IEnumerable<T> objetos, Func<T, bool> selecionar)
        {
            var resultados = new List<T>();

            foreach (var obj in objetos)
                if (selecionar(obj))
                    resultados.Add(obj);

            return resultados;
        }

        public static string AdicionarAspas(this string texto)
        {
            return "\"" + texto + "\"";
        }

        public static string RemoverTexto(this string texto, string textoASerRemovido)
        {
            return texto.Replace(textoASerRemovido, "");
        }

        public static int ContaVogais(this string texto)
        {
            var qtdeVogais = 0;

            foreach (var caractere in texto)
                if (EhVogal(caractere))
                    qtdeVogais++;

            return qtdeVogais;
        }

        public static bool EhVogal(this char caractere)
        {
            return "aeiouAEIOU".Contains(caractere);
        }
    }
}
