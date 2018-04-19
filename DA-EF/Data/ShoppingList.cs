using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("ShoppingLists")]
    public class ShoppingList
    {
        #region Identification
        [Key]
        [Column("ShoppingListKey")]
        public int? ID { get; set; }

        [ConcurrencyCheck]
        public byte? Concurrency { get; set; }
        #endregion

        #region Navigation
        public List<ShoppingListItem> Items { get; set; }
        #endregion

        public DateTime? BeginDate { get; set; }
    }
}
