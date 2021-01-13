using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var objTeste = new GenericsComRestricoes<Produto>();

            var produto = objTeste.RetornarInstancia();

            Console.WriteLine(produto.Id);






            //var lista = new Lista<int>();

            //lista.Adicionar(1);
            //lista.Adicionar(10);
            //lista.Adicionar(100);

            //Console.Write("Lista: ");

            //for (int i = 0; i < lista.Tamanho; i++)
            //{
            //    Console.Write($"{lista.GetElemento(i)}  ");
            //}

            //Console.WriteLine();

            Console.ReadKey();
        }
    }
}
