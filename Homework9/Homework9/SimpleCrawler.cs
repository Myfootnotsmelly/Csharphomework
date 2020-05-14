using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//将上次作业的爬虫程序，使用并行处理进行优化，实现更快速的网页爬取

namespace Homework10
{
    class Crawler
    {
        public event Action<Crawler, string> PageDownloaded;

        //所有已下载和待下载URL，key是URL，value表示是否下载成功
        private ConcurrentDictionary<string, bool> urls = new ConcurrentDictionary<string, bool>();

        //待下载队列
        private ConcurrentQueue<string> pending = new ConcurrentQueue<string>();

        //URL检测表达式，用于在HTML文本中查找URL
        private readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";

        //URL解析表达式
        public static readonly string urlParseRegex = @"^(?<site>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";
        public string HostFilter { get; set; } //主机过滤规则
        public string FileFilter { get; set; } //文件过滤规则
        public int MaxPage { get; set; } //最大下载数量
        public string StartURL { get; set; } //起始网址
        public Encoding HtmlEncoding { get; set; } //网页编码

        public Crawler()
        {
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
        }

        public void Start()
        {
            urls.Clear();
            pending.Enqueue(StartURL);

            List<Task> tasks = new List<Task>();
            int count = 0;//已完成任务数
            PageDownloaded += (crawler,someString) => { count++; };

            string url;
            while (count < MaxPage && pending.Count > 0)
            {
                if (!pending.TryDequeue(out url))
                {
                    if (count < tasks.Count)
                        continue;
                    else
                        break;//所有任务都完成，队列无url
                }
                Task task = Task.Run(() => DownloadAndParse(url));
                tasks.Add(task);

                /*try
                {
                    string html = DownLoad(url);
                    urls[url] = true;//该语句可以向字典里加入新项  ，相当于urls.add
                    PageDownloaded(this, url);
                    Parse(html, url);//解析,并加入新的链接
                }
                catch 
                {
                    PageDownloaded(this, url);                    
                }
                count++;*/

                Task.WaitAll(tasks.ToArray());
            }
        }


        private void DownloadAndParse(string url)
        {
            try
            {
                string html = DownLoad(url);
                urls[url] = true;
                Parse(html, url);//解析,并加入新的链接
                PageDownloaded(this,url);
            }
            catch 
            {
                PageDownloaded(this,url+"   but failed");
            }
        }
        private string DownLoad(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = urls.Count.ToString();
            File.WriteAllText(fileName, html, Encoding.UTF8);
            return html;
        }

        private void Parse(string html, string pageUrl)
        {

            var matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                linkUrl = FixUrl(linkUrl, pageUrl);//转绝对路径

                //解析出host和file两个部分，进行过滤
                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";


                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                  && !urls.ContainsKey(linkUrl))
                {
                    pending.Enqueue(linkUrl);
                    urls.TryAdd(linkUrl, false);
                }
            }
        }


        //将相对路径转为绝对路径
        static private string FixUrl(string url, string baseUrl)
        {
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("//"))
            {
                return "http:" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(baseUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }

            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = baseUrl.LastIndexOf('/');
                return FixUrl(url, baseUrl.Substring(0, idx));
            }

            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), baseUrl);
            }

            int end = baseUrl.LastIndexOf("/");
            return baseUrl.Substring(0, end) + "/" + url;
        }
    }
    

}
