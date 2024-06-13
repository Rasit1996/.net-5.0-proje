using BlogCoreApi.DataAccessLayer.Content;
using BlogCoreApi.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        ApiContext ctx = new ApiContext();
        [HttpGet]
        public IActionResult List()
        {
            var list = ctx.personels.ToList();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Ekle(personel p)
        {
            ctx.personels.Add(p);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var per=ctx.personels.SingleOrDefault(x=>x.ID==id); 
            if (per == null)
            {
                return NotFound();
            }
            return Ok(per);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var per=ctx.personels.SingleOrDefault(x=>x.ID==id);
            if (per == null)
            {
                return NotFound();
            }
            ctx.personels.Remove(per);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult   Guncelle(personel p)
        {
            var per = ctx.personels.SingleOrDefault(x => x.ID == p.ID);
            if (per==null)
            {
                return NotFound();
            }
            per.Adi=p.Adi;
            //ctx.personels.Update(p);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
