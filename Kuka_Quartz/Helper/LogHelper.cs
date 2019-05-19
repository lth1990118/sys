using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KuKa_Quartz.Helper
{
    public class LogHelper
    {
        public static void AddLog(string data)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                string FileName = AppDomain.CurrentDomain.BaseDirectory;
                if (FileName[FileName.Length - 1] == '\\')
                {
                    FileName += "Logs\\";
                }
                else
                {
                    FileName += "\\Logs\\";
                }
                if (!Directory.Exists(FileName))
                {
                    Directory.CreateDirectory(FileName);
                }
                FileName += DateTime.Now.ToString("yyyMMdd") + ".log";
                if (!File.Exists(FileName))
                {
                    FileStream tempfs = File.Create(FileName);
                    tempfs.Close();
                }

                fs = new FileStream(
                    FileName,
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.None);

                fs.Seek(0, System.IO.SeekOrigin.End);
                sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                string LineText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffff ") + data;
                sw.WriteLine(LineText);
                sw.WriteLine("==================================================================================");
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }

                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}