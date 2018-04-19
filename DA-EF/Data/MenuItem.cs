using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [Key]
        [Column("MenuItemKey")]
        public int? ID { get; set; }

        [ForeignKey("Menu")]
        [Column("MenuKey")]
        public int? MenuID { get; set; }

        [ForeignKey("MenuID")]
        public Menu Menu { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Description { get; set; }

        public bool Prepared { get; set; }
    }
}
