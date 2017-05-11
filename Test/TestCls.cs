using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestCls
    {
        public TestCls()
        {
            Name = string.Empty;
            Age = 33;
            Memo = "ddd";
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Memo { get; set; }
    }
}
