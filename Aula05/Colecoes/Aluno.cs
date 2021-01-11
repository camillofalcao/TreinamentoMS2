using System;
using System.Collections.Generic;
using System.Text;

namespace Listas
{
    class Aluno
    {
        /// <summary>
        /// Matrícula do aluno
        /// </summary>
        public int Matricula { get; set; }

        /// <summary>
        /// Nome do aluno
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Idade do aluno
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Compara se obj possui a mesma matrícula da instância corrente
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var outroObjeto = obj as Aluno;

            return outroObjeto != null && this.Matricula == outroObjeto.Matricula;
        }

        //"123".GetHashCode()

        public override int GetHashCode()
        {
            return $"##@CLASSE:Aluno@##{Matricula}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{Matricula} - {Nome}";
        }
    }
}
