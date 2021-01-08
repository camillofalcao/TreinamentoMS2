using System;
using System.Collections.Generic;
using System.Text;

namespace Listas
{
    class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public override bool Equals(object obj)
        {
            var outroObjeto = obj as Aluno;

            return outroObjeto != null && this.Matricula == outroObjeto.Matricula;
        }

        public override int GetHashCode()
        {
            return $"##@Aluno@##{Matricula}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{Matricula} - {Nome}";
        }
    }
}
