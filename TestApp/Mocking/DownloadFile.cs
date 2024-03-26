using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string filePath);
    }

    public class FileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            client.DownloadFile(url, path);
        }
    }
}
