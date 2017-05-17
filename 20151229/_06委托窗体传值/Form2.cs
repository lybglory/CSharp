using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06委托窗体传值
{   //声明一个委托，指向的方法就是form1窗体中的SendLabel方法，签名必须保持一致
    public delegate void DelSendString(string str);
    public partial class Form2 : Form
    {   //私有字段委托类型，用存储，方法
        private DelSendString _delSend;
        //构造函数,当创建form2对象的时候，传入一个委托，把给私有字段赋值
        public Form2(DelSendString del)
        {   //form1中如何可以访问form2中的委托呢？
            //当form1创建form2对象的时候，传入一个委托类型参数进去，
            //而方法又可以直接赋值给委托。当form1创建form2对象的时候，
            //就会把委托所指向的方法赋值给了委托，
            //form2中的构造函数就会把这个委托所指向的方法赋值给form2中的私有字段
            //这样form2窗体就拿到了form1窗体的SendLabel方法
            this._delSend = del;        
            InitializeComponent();
        }
        //当点击form2窗体中的button1，就触发委托所指向的方法。
        private void button1_Click(object sender, EventArgs e)
        {   //委托所指向的方法是form1中SendLabel赋值方法。
            _delSend(textBox1.Text);
        }
    }
}
