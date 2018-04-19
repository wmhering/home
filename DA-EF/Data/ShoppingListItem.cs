using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("ShoppingListItems")]
    public class ShoppingListItem
    {
        #region Itentification
        [Key]
        [Column("ShoppingListItemKey")]
        public int? ID { get; set; }
        #endregion

        #region Navigation
        [ForeignKey("ShoppingList")]
        [Column("ShoppingListKey")]
        public int? ShoppingListID { get; set; }

        [ForeignKey("ShoppingListID")]
        public ShoppingList ShoppingList { get; set; }
        #endregion
    }
}
