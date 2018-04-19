using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{

    [Table("RecipeIngredients")]
    public class RecipeIngredient
    {
        #region Identification
        [Key]
        [Column("RecipeIngredientKey")]
        public int? ID { get; set; }
        #endregion

        #region Navigation
        [ForeignKey("Recipe")]
        [Column("RecipeKey")]
        public int? RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public Recipe Recipe { get; set; }

        [ForeignKey("Section")]
        [Column("RecipeSectionKey")]
        public int? SectionID { get; set; }

        [ForeignKey("SectionID")]
        public RecipeSection Section { get; set; }
        #endregion

        public int Ordinal { get; set; }

        public decimal Quantity { get; set; }

        public string Unit { get; set; }

        public string Name { get; set; }

        public string Preparation { get; set; }
    }
}
