﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkEDAO.Models
{
    class Produto
    {
        public string ProdutoId { get; set; }
        public int Codigo { get; set; }

        //[Required]
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}
