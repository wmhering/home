using System;
using System.Collections.Generic;
using System.Text;

namespace Home.BO
{
    public class RecipeEditor
    {

        #region Properties
        public Int32? Key { get; set; }

        public Byte[] Concurrency { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String KeyWords { get; set; }

        public Int32? PreparationMinutes { get; set; }

        public String PreparationTime { get; set; }

        public Int32? CookingMinutes { get; set; }

        public String CookingTime { get; set; }

        public Int32? TotalMinutes { get; set; }

        public String TotalTime { get; set; }

        public Int32? NumberOfServings { get; set; }

        public String ServingSize { get; set; }

        public ICollection<Section> Sections { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Step> Steps { get; set; }
        #endregion

        public class Section
        {
            #region Properties
            public Int32? Key { get; set; }

            public Int32 Ordinal { get; set; }

            public String Name { get; set; }

            public String Description { get; set; }

            internal Int32 PreparationMinutes { get; set; }

            public string PreparationTime { get; set; }

            public Int32 CookingMinutes { get; set; }

            public String CookingTime { get; set; }

            public int? TotalMinutes { get; set; }

            public string TotalTime { get; set; }

            public ICollection<Ingredient> Ingredients { get; set; }

            public ICollection<Step> Steps { get; set; }
            #endregion
        }

        public class Ingredient
        {
            #region Properties
            public Int32 Key { get; set; }

            public Int32 Ordinal { get; set; }

            public Decimal Quantity { get; set; }

            public String Unit { get; set; }

            public String Name { get; set; }

            public String Preparation { get; set; }
            #endregion
        }

        public class Step
        {
            #region Properties
            public Int32 Key { get; set; }

            public Int32 Ordinal { get; set; }

            public String Description { get; set; }
            #endregion
        }
    }
}
