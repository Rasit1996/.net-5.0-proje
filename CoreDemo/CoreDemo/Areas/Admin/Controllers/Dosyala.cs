using ClosedXML.Excel;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Dosyala : Controller
    {
        BContext ctx = new BContext();
        public IActionResult ExeleAktar()
        {
            var list = ctx.kategoris.ToList();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Kategoriler");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int row = 2;
                foreach (var item in list)
                {
                    worksheet.Cell(row, 1).Value = item.ID;
                    worksheet.Cell(row, 2).Value = item.Adi;
                    row++;
                }
                using(var stream= new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "KategoriListesi.xlsx");
                }
            }
           
        }
    }
}
