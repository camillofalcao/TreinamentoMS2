using System;

namespace TesteInjecaoDependencia
{
    class Program
    {
        static void Main(string[] args)
        {
            string nome;

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Informe o seu nome: ");
                nome = Console.ReadLine();

                var recepcao = Instancia.Get<IRecepcao>();
                recepcao.Recepcionar(nome);
            }
            Console.ReadKey();
        }
    }
}
