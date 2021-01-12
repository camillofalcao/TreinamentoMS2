using System;
using System.Collections.ObjectModel;

namespace ColecaoObservavel
{
    class Program
    {
        static void Main(string[] args)
        {
            var lista = new ObservableCollection<int>();

            lista.CollectionChanged += Lista_CollectionChanged;

            Console.WriteLine("Adicionando o 1...");
            lista.Add(1);
            Console.WriteLine("Adicionando o 10...");
            lista.Add(10);
            Console.WriteLine("Adicionando o 5...");
            lista.Add(5);

            Console.WriteLine("Removendo o último...");
            lista.RemoveAt(lista.Count - 1);

            Console.ReadKey();
        }

        private static void Lista_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"Lista alterada ({e.Action})");
        }
    }
}
