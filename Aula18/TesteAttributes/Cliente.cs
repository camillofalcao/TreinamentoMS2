using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAttributes
{
    [Titulo("Cliente")]
    class Cliente
    {
        public string Nome { get; set; }
        [Titulo("E-mail")]
        public string Email { get; set; }
    }
}
