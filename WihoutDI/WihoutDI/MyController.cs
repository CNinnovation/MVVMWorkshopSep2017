using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WihoutDI
{
    public class MyController
    {
        public void Doit()
        {
            var service = new MyService();
            service.Foo();
        }
    }
}
