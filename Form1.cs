using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using OpcUaHelper;
using OpcUaHelper.Forms;

namespace OPC_UA_TEST
{
    public partial class Form1 : Form
    {
        private OpcUaClient opcUaClient = new OpcUaClient();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 异步方法 asunc await
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            //成功连接/断开连接时发生,要想监控连接需要写在连接前面
            opcUaClient.ConnectComplete += OpcUaClient_ConnectComplete;
            //opcUaClient.UserIdentity = new Opc.Ua.UserIdentity("admin", "123456");
            await opcUaClient.ConnectServer("opc.tcp://172.29.113.105:49320");
            
        }

        /// <summary>
        /// 成功连接/断开连接时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpcUaClient_ConnectComplete(object sender, EventArgs e)
        {

            //connected表示opcua连接状态
            textBox1.Text =opcUaClient.Connected.ToString();
        }
        /// <summary>
        /// 关闭窗体时断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            opcUaClient.Disconnect();
        }

        /// <summary>
        /// 获取服务器的所有节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getBrower_Click(object sender, EventArgs e)
        {
            using (FormBrowseServer form = new FormBrowseServer("opc.tcp://172.29.113.105:49320"))
            {
                form.ShowDialog();
            }
        }
        /// <summary>
        /// 无用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getServer_Click(object sender, EventArgs e)
        {
            //测试未成功
            //string endpointUrl =new DiscoverServerDlg().ShowDialog(opcUaClient.AppConfig, null);
            string endpointUrl = new DiscoverServerDlg().ShowDialog(opcUaClient.AppConfig, "opc.tcp://172.29.113.105:49320");
        }
        /// <summary>
        /// 单个节点读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadNote_Click(object sender, EventArgs e)
        {
            try
            {
                //读取前设定类型
                string value = opcUaClient.ReadNode<string>("ns=2;s=Pisces.Device.CP10.EDI");
                Int16 value1 = opcUaClient.ReadNode<Int16>("ns=2;s=Pisces.Device.CP10.Count_Down");
                MessageBox.Show(value + "\r\n" + value1); // 显示测试数据
            }
            catch (Exception ex)
            {
                // 使用了opc ua的错误处理机制来处理错误，网络不通或是读取拒绝
                ClientUtils.HandleException(Text, ex);
            }
        }
        /// <summary>
        /// 批量读取节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readNotes_Click(object sender, EventArgs e)
        {
            try
            {
                // 如果批量读取的值不一样
                List<NodeId> nodeIds = new List<NodeId>();
                nodeIds.Add(new NodeId("ns=2;s=Pisces.Device.CP10.EDI"));
                nodeIds.Add(new NodeId("ns=2;s=Pisces.Device.CP10.Count_Down"));
                List<DataValue> dataValues = opcUaClient.ReadNodes(nodeIds.ToArray());
                foreach (var dataValue in dataValues)
                {
                    // 获取你的实际的数据
                    object value = dataValue.WrappedValue.Value;
                }

                // 如果批量读取的值的类型都是一样的，比如float，那么有简便的方式
                List<string> tags = new List<string>();
                tags.Add("ns=2;s=Pisces.Device.CP10.EDI");
                tags.Add("ns=2;s=Pisces.Device.CP11.EDI");

                // 按照顺序定义的值
                List<string> values = opcUaClient.ReadNodes<string>(tags.ToArray());
                textBox1.Text = values[0] + "\r\n" + values[1];

            }
            catch (Exception ex)
            {
                ClientUtils.HandleException(this.Text, ex);
            }
        }

        /// <summary>
        /// 单个节点写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeNote_Click(object sender, EventArgs e)
        {
            try
            {
                bool IsSuccess = opcUaClient.WriteNode<Int16>("ns=2;s=Pisces.Device.SPS8.C_P1_number", 111);
                MessageBox.Show(IsSuccess.ToString()); // 显示True，如果成功的话

                bool IsSuccess1 = opcUaClient.WriteNode<string>("ns=2;s=Pisces.Device.SPS8.EDI_A", "test");
                MessageBox.Show(IsSuccess1.ToString()); // 显示True，如果成功的话
            }
            catch (Exception ex)
            {
                // 使用了opc ua的错误处理机制来处理错误，网络不通或是读取拒绝
                ClientUtils.HandleException(Text, ex);
            }
        }

        /// <summary>
        /// 批量写入节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeNotes_Click(object sender, EventArgs e)
        {
            string[] nodes = new string[]
            {
                "ns=2;s=Pisces.Device.SPS8.C_P1_number",
                //"ns=2;s=Pisces.Device.SPS8.C_P2_number"
                "ns=2;s=Pisces.Device.SPS8.EDI_A"
            };

            //写入的数据需要注明类型,如(int)22
            object[] data = new object[]
            {
               (Int16)22,"ASDF"
            };

            // 都成功返回True，否则返回False
            bool result = opcUaClient.WriteNodes(nodes, data);
            textBox1.Text = result.ToString();
        }

        /// <summary>
        /// 订阅节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_subscription_Click(object sender, EventArgs e)
        {
            opcUaClient.AddSubscription("A", "ns=2;s=Pisces.Device.SPS8.C_P1_number", SubCallback);
        }
        private void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
        {
            //调用方位于创建控件所在的线程以外的线程中,true
            if (InvokeRequired)
            {
                //线程调用将调用消息推送到主线程执行
                Invoke(new Action<string, MonitoredItem, MonitoredItemNotificationEventArgs>(SubCallback), key, monitoredItem, args);
                return;
            }
            ////或者 指定不再捕获对错误线程的调用
            //Control.CheckForIllegalCrossThreadCalls = false;
            if (key == "A")
            {
                // 如果有多个的订阅值都关联了当前的方法，可以通过key和monitoredItem来区分
                MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
                if (notification != null)
                {
                    textBox1.Text = notification.Value.WrappedValue.Value.ToString();
                }
            }
        }
        /// <summary>
        /// 用不到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_getlog_Click(object sender, EventArgs e)
        {
            // False 代表每次启动清空日志，True代码不清空，注意，该日志大小增加非常快
            opcUaClient.SetLogPathName(Application.StartupPath + "\\Logs\\opc.ua.client.txt", false);
        }
    }
}
