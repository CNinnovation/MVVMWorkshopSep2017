using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WihoutDI
{
    public class MyController
    {
        private readonly IMyService _myService;
        public MyController(IMyService myService)
        {
            _myService = myService;

        }

        public void Doit()
        {
            _myService.Foo();
        }
    }
}
