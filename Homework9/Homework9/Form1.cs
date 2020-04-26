using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace Homework9
{
    public partial class Form1 : Form
    {
        BindingSource resultBindingSource = new BindingSource();
        Crawler crawler = new Crawler();
        Thread thread = null;
        public Form1()
        {
            InitializeComponent();
            dgvCramler.DataSource = resultBindingSource;
            crawler.PageDownloaded += Crawler_PageDownloaded;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            resultBindingSource.Clear();
            crawler.StartURL = txtURL.Text;

            Match match = Regex.Match(crawler.StartURL, Crawler.urlParseRegex);
            if (match.Length == 0) return;
            string host = match.Groups["host"].Value;
            crawler.HostFilter = "^" + host + "$";
            crawler.FileFilter = ".html?$";

            if (thread != null)
            {
                thread.Abort();
            }
            thread = new Thread(crawler.Start);
            thread.Start();
        }
        private void Crawler_PageDownloaded(Crawler crawler, string url, string info)
        {
            var pageInfo = new {  URL = url};
            Action action = () => { resultBindingSource.Add(pageInfo); };
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
