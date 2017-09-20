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
            var controller = new MyController(new MyService());
            controller.Doit();
        }
    }
}
