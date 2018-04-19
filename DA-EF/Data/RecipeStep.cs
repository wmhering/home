using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("RecipeSteps")]
    public class RecipeStep
    {
        #region Identification
        [Key]
        [Column("RecipeStepKey")]
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

        public string Description { get; set; }
    }
}
