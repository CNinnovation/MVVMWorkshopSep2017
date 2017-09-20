using BooksLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMSampleApp.LocalServices
{
    public class WPFDialogService : IDialogService
    {
        public Task ShowMessageAsync(string message)
        {
            return Task.Run(() =>
            {
                MessageBox.Show(message);
            });
        }
    }
}
