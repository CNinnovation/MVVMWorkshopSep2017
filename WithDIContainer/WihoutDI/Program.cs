using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WihoutDI
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterServices();

            var controller = Container.GetService<MyController>();
            controller.Doit();
        }

        static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMyService, MyService>();
            services.AddTransient<MyController>();
            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
