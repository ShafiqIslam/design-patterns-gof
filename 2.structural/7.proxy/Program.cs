using System;
using System.Collections.Generic;

namespace DesignPatterns.Structural.Proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create math proxy
            IYoutubeVideoLoader loader = new ProxyYoutubeVideoLoader();
            loader.Load("https://www.youtube.com/watch?v=9Oa_mWpckns");
            loader.Load("https://www.youtube.com/playlist?list=PLmmYSbUCWJ4x1GO839azG_BBw8rkh-zOj");
            loader.Load("https://www.youtube.com/watch?v=9Oa_mWpckns");
            loader.Load("https://www.youtube.com/watch?v=m1a_xxxKlf");
        }
    }
    
    public interface IYoutubeVideoLoader
    {
        void Load(string url);
    }
    
    public class YoutubeVideoLoader : IYoutubeVideoLoader
    {
        public void Load(string url) 
        {
            Console.WriteLine("Load video form source: " + url);
        }
    }
    
    public class ProxyYoutubeVideoLoader : IYoutubeVideoLoader
    {
        private YoutubeVideoLoader loader = new YoutubeVideoLoader();

        private Dictionary<string, bool> loadedVideos = new Dictionary<string, bool>();

        public void Load(string url) 
        {
            if (loadedVideos.ContainsKey(url))
            {
                Console.WriteLine("Load video form cache: " + url);
                return;
            }

            if (url.Contains("xxx"))
            {
                Console.WriteLine("Nasty video found. Not loaded.");
                return;
            }

            loader.Load(url);
            loadedVideos[url] = true;
        }
    }
}