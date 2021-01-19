using System;

namespace TrabalhoSolucao1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoas = new Pessoa[]
            {
                new PessoaFisica { Nome = "Ana", Cpf = "123"},
                new PessoaJuridica { Nome = "Empresa 1", Cnpj = "111", Contato = "José da Silva" },
                new PessoaFisica { Nome = "Bruno", Cpf = "125"},
                new PessoaJuridica { Nome = "Empresa 2", Cnpj = "222", Contato = "Maria da Silva" },
                new PessoaFisica { Nome = "Carlos", Cpf = "127"}
            };

            (new PessoaEtiquetaService()).Imprimir(pessoas);
            (new PessoaCartaCobrancaService()).Imprimir(pessoas);
            (new PessoaNotaPromissoriaService()).Imprimir(pessoas, 100);
            
        }
    }
}
