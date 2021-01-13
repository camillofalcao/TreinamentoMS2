using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    abstract class Entidade : ICloneable
    {
        public string Id { get; set; }

        public abstract object Clone();
    }
}
