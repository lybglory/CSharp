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
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //点击button1的时候，创建form2窗体，弹出form2窗体
        private void button1_Click(object sender, EventArgs e)
        {   //传入一个委托类型的参数，方法可以直接赋值给委托。
            //那么就把委托所指向的方法赋值给这个构造函数参数。
            //这样，form2窗体就拿到了SendLabel赋值方法。
            Form2 fm2 = new Form2(SendLablel);
            fm2.Show();
        }

        //传入string类型参数，把这个参数赋值给label1，这个传递过来的参数就是form2中的TexBox1.Text
        //这个赋值方法，就是委托所指向的方法。也就说说，form2窗体拿到了这个赋值方法。
        private void SendLablel(string str) {
            label1.Text = str;      
        }
    }
}
