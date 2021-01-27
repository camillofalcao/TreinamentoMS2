using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace TesteInjecaoDependencia
{
    static class Instancia
    {
        static Instancia()
        {
            IServiceCollection services = new ServiceCollection()
                .AddSingleton<ISaudacao, SaudacaoAmigavel>()
                .AddTransient<IRecepcao, RecepcaoDireta>();

            provedor = services.BuildServiceProvider();
        }

        public static T Get<T>() => provedor.GetService<T>();

        private static ServiceProvider provedor;
    }
}
