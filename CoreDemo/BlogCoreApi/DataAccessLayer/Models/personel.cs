using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace BlogCoreApi.DataAccessLayer.Models
{
    public class personel
    {
        [Key]
        public int ID { get; set; }
        public string  Adi { get; set; }
    }
}
