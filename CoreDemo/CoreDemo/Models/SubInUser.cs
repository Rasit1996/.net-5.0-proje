using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace CoreDemo.Models
{
    public class SubInUser
    {
        [Required(ErrorMessage ="Bu alan gerekli!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Bu alan gerekli")]
        public string  Sifre { get; set; }

      
    }
}
