using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class HaberBulteni
	{
        [Key]
        public int ID { get; set; }
        public string  Mail { get; set; }
        public bool Durum { get; set; }
    }
}
