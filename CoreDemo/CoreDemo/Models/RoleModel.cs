using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string name { get; set; }
    }
}
