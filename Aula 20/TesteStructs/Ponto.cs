using System;
using System.Collections.Generic;
using System.Text;

namespace TesteStructs
{
    struct Ponto
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double GetDistancia(Ponto outro)
        {
            return Math.Sqrt(Math.Pow(X - outro.X, 2) + Math.Pow(Y - outro.Y, 2));
        }

        public override bool Equals(object obj)
        {
            if (obj is Ponto)
            {
                var outro = (Ponto)obj;
                return X == outro.X && Y == outro.Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return $"##@{this.GetType().FullName}@##:{X},{Y}".GetHashCode();
        }

        public static bool operator ==(Ponto esq, Ponto dir)
        {
            return esq.X == dir.X && esq.Y == dir.Y;
        }

        public static bool operator !=(Ponto esq, Ponto dir)
        {
            return esq.X != dir.X || esq.Y != dir.Y;
        }
    }
}
