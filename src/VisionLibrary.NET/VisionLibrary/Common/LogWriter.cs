using System;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using System.Windows;

namespace VisionLibrary.Common
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public class LogWriter
    {
        /// <summary>用户ID</summary>
        public static string UserId = string.Empty;

        /// <summary>系统名称</summary>        

        /// <summary>背景图片</summary>
        public static Image BackImage = null;

        public static string ProjectName = string.Empty;

        public static string ProjectPath = string.Empty;
        
        /// <summary>
        /// 写入异常日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLog(Exception ex)
        {
            try
            {
                //记录异常模块、类、方法、行号及其StackTrace、Source
                string path = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath + "\\Logs";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "\\" + DateTime.Now.Year;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "\\" + DateTime.Now.ToString("yyyyMM");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                //创建流
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                //写入
                sw.Write("\r\n操作时间：" + DateTime.Now + "\r\n错误日志：" + ex);
                //清除缓存
                sw.Flush();
                //关闭
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }

        public static void WriteLog(string ex)
        {
            try
            {
                //记录异常模块、类、方法、行号及其StackTrace、Source
                string path = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath + "\\Logs";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "\\" + DateTime.Now.Year;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "\\" + DateTime.Now.ToString("yyyyMM");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                //创建流
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                //写入
                sw.Write("\r\n操作时间：" + DateTime.Now + "\r\n错误日志：" + ex);
                //清除缓存
                sw.Flush();
                //关闭
                sw.Close();
                fs.Close();
            }
            catch
            {
            }
        }
    }
}