using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class SubIdentityUser
    {
        public string Adi { get; set; }
        public string  Soyadi { get; set; }

        [Required(ErrorMessage ="Bu alanın girilmesi zorunludur!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bu alanın girilmesi zorunludur!")]
        public string Sifre { get; set; }

        [Compare("Sifre",ErrorMessage ="Şifreler uyuşmuyor")]
        public string SifreTekrar { get; set; }
        public string  ImageUrl { get; set; }

    }
}
