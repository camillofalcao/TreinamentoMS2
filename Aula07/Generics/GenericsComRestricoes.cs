using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{ 
    class GenericsComRestricoes<T> where T: Produto, ICloneable, new()
    {
        public T RetornarInstancia()
        {
            return new T { Id = Guid.NewGuid().ToString() };
        }
    }
}
