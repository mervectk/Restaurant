using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Category
    {
        [Key]// ID Attribute ile benzersiz yaptık
        public int Id { get; set; }
        [Required]//Name boş geçilmemesi için attribute tanımladık.
       public string Name { get; set; }
    }
}
