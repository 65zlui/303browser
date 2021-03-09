using System;
using System.ComponentModel;
using System.Windows.Forms;
using CCWin;

namespace SherryMusic
{
    public partial class Form : CCSkinMain
    {
        public Form()
        {            
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                //关闭程序
            }
            else
            {
                e.Cancel = true;//保持状态
                this.Hide(); //隐藏窗体 
                this.ShowInTaskbar = false;//图标不显示在任务栏上 
            }
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement archor in this.webBrowser.Document.Links)
            {

                archor.SetAttribute("target", "_self");

            }

            //将所有的FORM的提交目标，指向本窗体

            foreach (HtmlElement form in this.webBrowser.Document.Forms)
            {

                form.SetAttribute("target", "_self");

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                webBrowser.Navigate(textBox1.Text);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser.Url.ToString();//页面跳转后改变地址栏地址
        }

        private void webBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel=true;
           /* try
            {
                string url = this.webBrowser.Document.ActiveElement.GetAttribute("href");

                this.webBrowser.Url = new Uri(url);
            }
            catch
            {
            }*/
        }
    }
}
