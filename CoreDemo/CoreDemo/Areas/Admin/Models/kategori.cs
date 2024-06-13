using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Areas.Admin.Models
{
    public class kategori
    {
        [Required(ErrorMessage ="Doldurulacak bi kategori adı var zaten. Bunu da mı boş geçeceksin? :)")]
        public string Adi { get; set; }
    }
}
