using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("RecipeSections")]
    public class RecipeSection
    {
        #region Identification
        [Key]
        [Column("RecipeSectionKey")]
        public int? ID { get; set; }
        #endregion

        #region Navigation
        [ForeignKey("Recipe")]
        [Column("RecipeKey")]
        public int? RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public Recipe Recipe { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<RecipeStep> Steps { get; set; }
        #endregion

        public string Name { get; set; }

        public string Description { get; set; }

        public int? PreparationMinutes { get; set; }

        public int? CookingMinutes { get; set; }

        public int? TotalMinutes { get; set; }
    }
}
