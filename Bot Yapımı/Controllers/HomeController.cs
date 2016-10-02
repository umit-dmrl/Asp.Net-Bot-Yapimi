using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net;
using HtmlAgilityPack;

namespace Bot_Yapımı.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        { 
            return View();
        }
        public void HaberBotu()
        {
            Uri url = new Uri("http://www.haberler.com/gunun-mansetleri/");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);

            HtmlAgilityPack.HtmlNodeCollection basliklar = document.DocumentNode.SelectNodes("//ul[@class='gridView']");

            foreach (var baslik in basliklar)
            {
                Response.Write(baslik.InnerHtml.ToString().Replace("Ä°", "İ").Replace("Ä±", "ı").Replace("Ã&frac14;", "ü").Replace("ÅŸ", "ş").Replace("Å", "Ş").Replace("Ã§", "ç").Replace("Ã¶", "ö").Replace("ÄŸ", "ğ").Replace("Ã‡", "Ç").Replace("Ã–", "Ö").Replace("Ãœ", "Ü").Replace("Ã¼", "ü"));
            }
        }

    }
}
