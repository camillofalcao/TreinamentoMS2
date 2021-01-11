using System;
using System.Collections.Generic;

namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {
            var alunos = new List<Aluno>();

            alunos.Add(RetornarAluno(123));
            alunos.Add(RetornarAluno(125));

            /*
            var turma = new Turma();
            turma.Alunos = alunos;
            */

            Console.WriteLine($"Tamanho da lista: {alunos.Count}");

            Imprimir(alunos);

            var b = RetornarAluno(125);

            if (alunos.Contains(b))
                Console.WriteLine($"O(a) aluno(a) {b.Nome} está presente.");

            //idades.Remove(25);
            //alunos.RemoveAt(1);

            //Imprimir(alunos);

            Console.ReadKey();
        }

        private static Aluno RetornarAluno(int matricula)
        {
            if (matricula == 123)
                return new Aluno { Matricula = 123, Nome = "Ana", Idade = 20 };
            else if (matricula == 125)
                return new Aluno { Matricula = 125, Nome = "Bruno", Idade = 21 };
            else
                return null;
        }

        private static void Imprimir(IList<Aluno> alunos)
        {
            Console.WriteLine("Alunos informados: ");

            foreach (var a in alunos)
                Console.WriteLine(a);
                //Console.WriteLine($"  Nome: {a.Nome}, matrícula: {a.Matricula}, idade: {a.Idade}");

            /*
            IEnumerable<Aluno> lista = alunos;

            IEnumerator<Aluno> enumerator = lista.GetEnumerator();

            enumerator.Reset();

            while (enumerator.MoveNext())
                Console.WriteLine($"Nome: {enumerator.Current.Nome} - matrícula: {enumerator.Current.Matricula}");
            */
        }
    }
}
