using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03序列化和反序列化
{
    [Serializable]
    public class Person
    {
        public int Age { set; get; }
        public string Name { set; get; }
    }
}
