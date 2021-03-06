﻿using System;using System.Collections.Generic;using System.IO;using System.Linq;using System.Net;using System.Text;using System.Threading.Tasks;namespace PiexelParadisServerTool{
    class HttpStringGet
    {
        /// <summary>  
        /// 获取网页的HTML
        /// </summary>  
        /// <param name="url">链接地址:string</param>  
        /// <returns></returns>  
        public static string GetHtmlStr(string url) => GetHtmlStr(url, Encoding.Default);

        /// <summary>  
        /// 获取网页的HTML
        /// </summary>  
        /// <param name="url">链接地址:string</param>  
        /// <param name="encoding">编码类型:Encoding</param>  
        /// <returns></returns>  
        public static string GetHtmlStr(string url, Encoding encoding)
        {
            string htmlStr = "Null";
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    WebRequest request = WebRequest.Create(url);            //实例化WebRequest对象  
                    WebResponse response = request.GetResponse();           //创建WebResponse对象  
                    Stream datastream = response.GetResponseStream();       //创建流对象  
                    StreamReader reader = new StreamReader(datastream, encoding);
                    htmlStr = reader.ReadToEnd();                  //读取网页内容  
                    reader.Close();
                    datastream.Close();
                    response.Close();
                }
            }
            catch { return "Error!"; }
            return htmlStr;
        }





        public static bool HttpFileExist(string fileUrl)
        {
            try
            {
                //创建根据网络地址的请求对象
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.CreateDefault(new Uri(fileUrl));
                httpWebRequest.Method = "HEAD";
                httpWebRequest.Timeout = 1000;
                //返回响应状态是否是成功比较的布尔值
                return (((HttpWebResponse)httpWebRequest.GetResponse()).StatusCode == System.Net.HttpStatusCode.OK);
                //using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
                //{
                //    return response.StatusCode == HttpStatusCode.OK;
                //}
            }
            catch (Exception)
            {
                return false;
            }
        }



    }}