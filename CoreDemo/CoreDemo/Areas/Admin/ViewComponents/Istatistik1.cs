using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents
{
    public class Istatistik1:ViewComponent
    {
        BContext ctx=new BContext();
        public async Task< IViewComponentResult > InvokeAsync()
        {
            ViewBag.blog = await ctx.bloks.CountAsync();
            ViewBag.yorum = await ctx.bloks.CountAsync();
            string api= "7b5a7e996f701fbd923823be56ad8b6e";
            string connection = 
                "https://api.openweathermap.org/data/2.5/weather?q=Dar%C4%B1ca&mode=xml&lang=Tr&units=metric&appid=" + api;
            XDocument dosya = XDocument.Load(connection);
            ViewBag.sehir = dosya.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.sicaklik = dosya.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
