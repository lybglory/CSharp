using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace _03序列化和反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pr = new Person() { Age = 29, Name = "Messi" };
            // 固定语法typeof(类型)
            //XmlSerializer xmlSer = new XmlSerializer(typeof(Person));
            //using (FileStream fsRead = new FileStream("pr.xml",FileMode.Open,FileAccess.Read)) {
            //    Person pr =xmlSer.Deserialize(fsRead) as Person;
            //}

            JavaScriptSerializer jsSer = new JavaScriptSerializer();
            string jsSerStr = jsSer.Serialize(pr);
            Person jspr = jsSer.Deserialize(jsSerStr, typeof(Person)) as Person;
        }
    }
}

