using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WihoutDI
{
    public class MyService : IMyService
    {
        public void Foo() => Console.WriteLine(nameof(Foo));
    }
}
