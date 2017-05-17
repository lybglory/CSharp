using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09Scoket网络编程
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {   //创建一个负责监听的Socket对象（引入命名空间）
            //AddressFamily.InterNetwork, 
            //SocketType.Stream,
            //ProtocolType.Tcp
            try {
                Socket skListen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //创建IP地址对象(引入命名空间)
                IPAddress ip = IPAddress.Any;//监听所有活动的网络IP
                                             //创建端口对象new IPEndPoint(IPAddress ip,int port与IP地址关联的端口号)
                IPEndPoint port = new IPEndPoint(ip, int.Parse(textPort.Text));
                //让负责监听的Socket绑定IP和端口号
                skListen.Bind(port);    //为何传入端口号就行？因为端口号已经和IP地址绑定在一起了
                                        //设置监听队列
                                        //.Listen(int backlog挂起连接队列的最大长度)  将Socket处于监听状态
                skListen.Listen(10);
                ShowMessage("监听成功！");
                //开启新的线程来执行SkListen方法
                Thread th = new Thread(ListenSk);
                th.IsBackground = true;
                th.Start(skListen); //传入参数
            } catch { }
        }

        //TextBox显示监听日志
         void ShowMessage(string str) {
            textLog.AppendText(str + "\r\n");   //文件追加
        }

        //为了方便其他方法访问通信的Socket，把它写在外边
        Socket skCorrespondence;
        //skListen在通信方法中就访问不到了，可以传入一个Socket，
        //但这个方法最终被线程执行，线程执行带有参数的方法，这个方法的参数必须是object

        /// <summary>
        /// 负责监听客户端的连接，并创建通信的Socket
        /// </summary>
        /// <param name="obj"></param>
        void ListenSk(object obj)
        {//监听客户端的连接，创建跟客户端通信的Socket
            Socket skListen = obj as Socket;
            while (true) {//需要不停的去监听
                try {
                    //通过Accept这个方法，创建一个负责和客户端通信的Socket
                    skCorrespondence = skListen.Accept();
                    //获取远程(客户端)的IP和端口号
                    ShowMessage(skCorrespondence.RemoteEndPoint.ToString() + "连接成功");
                    //服务端开始接收客户端发来的数据
                    //只接收到一个字符，这是因为在while循环中，
                    //当执行完成之后，又回到了true，回到Socket这里，等待新的客户端连接
                    //因此只接收到了一个字符。我们需要不停地去接收数据。
                    //在开一个新线程，用来执行接收数据。
                    //byte[] buffer = new byte[1024 * 1024 * 2];
                    ////服务器端实际接收到有效字节数
                    //int r = skCorrespondence.Receive(buffer);
                    ////接收的数据显示到文本框中，因此r需要转换成字符串
                    //string strText = System.Text.Encoding.UTF8.GetString(buffer, 0, r);
                    //ShowMessage(skCorrespondence.RemoteEndPoint.ToString() + ":" + strText);

                    //开启新的线程用来不停的接收客户端发来的数据
                    Thread thRec = new Thread(Receive);
                    thRec.IsBackground = true;
                    thRec.Start(skCorrespondence);//传入负责通信的Socket。
                } catch { }
            }
        }

        /// <summary>
        /// 不停地接受客户端发来的消息
        /// </summary>
        /// <param name="obj">传入通信的Socket</param>
        void Receive(object obj) {//负责通信的Socket又访问不到了。所以要传入一个参数
            Socket skCorrespondence = obj as Socket;
            while (true) {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];

                    //当客户端停止发送数据的时候，会发现程序死在while-true循环中
                    //它在不停的接收。所以需要做个判断，
                    //如果客户端没有消息发送过来，那么就跳出循环，
                    //没有消息发送过来，其实就是服务器端实际接收的字节数为0
                    int r = skCorrespondence.Receive(buffer);  //服务器端实际接收到有效字节数
                    if (r == 0)
                    {   //break;  //用break终止循环也可以。
                        return;
                    }
                    //接收的数据显示到文本框中，因此r需要转换成字符串
                    string strText = System.Text.Encoding.UTF8.GetString(buffer, 0, r);
                    ShowMessage(skCorrespondence.RemoteEndPoint.ToString() + ":" + strText);
                } catch {

                }   
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSerSend_Click(object sender, EventArgs e)
        {
            string sentText = textSerSentText.Text;
            byte[] sentBytes = System.Text.Encoding.UTF8.GetBytes(sentText);
            skCorrespondence.Send(sentBytes);
            
        }
    }
}
