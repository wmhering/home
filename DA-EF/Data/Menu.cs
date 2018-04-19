using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("Menus")]
    public class Menu
    {
        #region Identification
        [Key]
        [Column("MenuKey")]
        public int? ID { get; set; }

        [ConcurrencyCheck]
        public byte? Concurrency { get; set; }
        #endregion

        #region Navigation
        public List<MenuItem> Items { get; set; }
        #endregion

        public DateTime? BeginDate { get; set; }
    }
}
