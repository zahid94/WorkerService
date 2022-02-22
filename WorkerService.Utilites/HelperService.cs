using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WorkerService.Utilites
{
    public class HelperService: IHelperService
    {
        private readonly IConfiguration _configuration;
        public HelperService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Text(string text)
        {
            string rootPath = Path.Combine(_configuration.GetSection("LOG").Value, DateTime.Now.ToString("MMM-yyyy"),DateTime.Now.ToString("dd"));
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            StreamWriter sw;
            rootPath = Path.Combine(rootPath, "log.txt");
            if (File.Exists(rootPath))
            {
                //append text when file is exists
                sw = File.AppendText(rootPath);
                sw.WriteLine(Environment.NewLine + "execution Time: " + DateTime.Now.ToString("dd-MMM-yyyy(hh-mm-ss-tt)") + Environment.NewLine + text);
                sw.Close();
            }
            else
            {
                // Create a file to write to.
                sw = File.CreateText(rootPath);
                sw.WriteLine("execution Time: " + DateTime.Now.ToString("dd-MMM-yyyy(hh-mm-ss-tt)") + Environment.NewLine + text);
                sw.Close();
            }
        }
    }

    public interface IHelperService
    {
        void Text(string text);
    }
}
