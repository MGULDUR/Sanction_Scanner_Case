using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Sanction_Scanner_Case.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sanction_Scanner_Case.Controllers
{
    public class SiteController : Controller
    {
        public IActionResult Index()   
        {
            /*Kütüphane olarak htmlagilitypack  kullandım.
             Kod bloğu çalışıyor. Fakat Sahibinden.com dan değer boş geliyor.
            Bence sitenin güvenliği ile ilgili bir durum. 
            Güvenliği bir türlü aşamadım.
            Başka sitede denedim veri çekmeyi başardım.
             
             */


            string mainUrl = "https://www.sahibinden.com/anasayfa-vitrin?viewType=Gallery&pagingSize=50";
           
           
            HtmlWeb htmlWeb = new HtmlWeb();
            HtmlDocument doc2 = htmlWeb.Load(mainUrl);
           
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("user-agent", Guid.NewGuid().ToString());        

            
            List<ModelView> modelList = new List<ModelView>();

            

            for (int i = 1; i <= 50; i++)
            {
                for (int j = 1; i <= 2; i++)
                {



                    string xpath1 = "/html/body/div[5]/div[4]/form/div/div[3]/div[2]/table/tbody/tr[" + i + "]/td[" + j + "]/table/tbody/tr/td[2]/div[1]/a";
                    string xpath2 = "/html/body/div[5]/div[4]/form/div/div[3]/div[2]/table/tbody/tr[" + i + "]/td[" + j + "]/table/tbody/tr/td[2]/div[2]/div/span";


                    ModelView model = new ModelView();
                    model.Name = doc2.DocumentNode.SelectSingleNode(xpath1).InnerText;
                    model.Price= doc2.DocumentNode.SelectSingleNode(xpath2).InnerText;
                    modelList.Add(model);

                }
            }

            
            return View(modelList);
        }
    }
}
