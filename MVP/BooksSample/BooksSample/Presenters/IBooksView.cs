using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BooksSample.Presenters
{
    public interface IBooksView
    {
        ListBox BooksList { get; }
    }
}
