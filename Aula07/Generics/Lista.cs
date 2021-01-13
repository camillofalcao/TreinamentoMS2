using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    class Lista<T>
    {
        public void Adicionar(T valor)
        {
            if (tamanho == itens.Length)
                throw new Exception("Lista cheia.");
            
            itens[tamanho++] = valor;
        }

        public int Tamanho { get => tamanho; }

        public T GetElemento(int indice)
        {
            if (indice < 0 || indice >= itens.Length)
                throw new Exception("Índice inválido!");

            return itens[indice];
        }

        private T[] itens = new T[1000];
        private int tamanho = 0;
    }
}
