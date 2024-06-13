using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class SubIChangePasswordUser
    {
        [Required(ErrorMessage = "Bu alan gerekli!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alan gerekli")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "Bu alan gerekli")]
        public string SifreTekrar { get; set; }
    }
}
