using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationSample
{
    //public class Demo
    //{
    //    public void Foo()
    //    {
    //        SampleData x = new SampleData();
    //        string s = x["Text2"];
    //    }
    //}

    public class SampleData : IDataErrorInfo
    {
        private string text1;

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Text2))
                {
                    if (Text2?.Length > 5)
                    {
                        _error = "text2 ist zu lang";
                        return _error;
                    }
                }
                return null;
            }
        }

        public string Text1
        {
            get { return text1; }
            set
            {
                if (value.Length > 5) throw new Exception("bad value");
                text1 = value;
            }
        }

        public string Text2 { get; set; }

        private string _text3;
        public string Text3
        {
            get => _text3;
            set => _text3 = value;
        }

        private string _error;
        public string Error => _error;
    }
}
