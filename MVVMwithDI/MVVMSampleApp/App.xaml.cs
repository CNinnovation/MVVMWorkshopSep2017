using BooksLib.Services;
using Microsoft.Extensions.DependencyInjection;
using MVVMSampleApp.LocalServices;
using MySharedLib.Services;
using MySharedLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMSampleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
        }

        public void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IBooksService, BooksService>();
            services.AddSingleton<IDialogService, WPFDialogService>();
            services.AddTransient<BooksViewModel>();
            services.AddTransient<BookViewModel>();
            
            Container = services.BuildServiceProvider();
        }

        public IServiceProvider Container { get; private set; }
    }
}
