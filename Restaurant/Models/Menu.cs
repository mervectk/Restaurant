using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Menu
    {
        [Key] //id benzersiz olacak
        public int Id { get; set; }

        [Required] //alan boş geçilemeyecek
        public string Title{ get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public bool OzelMenu { get; set; } //MENÜ ÖZEL İSE ANA SAYFADA DA GÖZÜKÜR.

        public double Price { get; set; }
        public int CategoryId { get; set; } //her menünün bir kategorisi olacak.
       
        [ForeignKey("CategoryId")]
        public Category Category{ get; set; } //Menu classını Kategori classı ile ilişkilendirdik.

    }
}
