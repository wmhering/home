using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home.DA.Data
{
    [Table("Recipes")]
    public class Recipe
    {
        #region Itenification
        [Key]
        [Column("RecipeKey")]
        public int? ID { get; set; }

        [ConcurrencyCheck]
        public byte[] Concurrency { get; set; }
        #endregion

        #region Navigation
        public List<RecipeIngredient> Ingredients { get; set; }

        public List<RecipeSection> Sections { get; set; }

        public List<RecipeStep> Steps { get; set; }
        #endregion

        public string Name { get; set; }

        public string Description { get; set; }

        public string KeyWords { get; set; }

        public int? PreparationMinutes { get; set; }

        public int? CookingMinutes { get; set; }

        public int? TotalMinutes { get; set; }

        public int? NumberOfServings { get; set; }

        public string ServingSize { get; set; }
    }
}
