using System;

namespace Home.BO
{
    [Serializable]
    /// <summary>
    /// Information to be used to select a recipe.</summary>
    public class RecipeSummary
    {
        #region Constructors
        public RecipeSummary() { }

        public RecipeSummary(int key, byte[] concurrency, string name, string description, string keyWords,
            string preparationTime, string cookingTime, string totalTime, string servings)
        {
            Key = key;
            Concurrency = concurrency;
            Name = name;
            Description = description;
            KeyWords = keyWords;
            PreparationTime = preparationTime;
            CookingTime = cookingTime;
            TotalTime = totalTime;
            Servings = servings;
        }
        #endregion

        #region Properties
        public int Key { get; private set; }

        /// <summary>
        /// </summary>
        public byte[] Concurrency { get; private set; }

        /// <summary>
        /// The name of this recipe.</summary>
        public string Name { get; private set; }

        /// <summary>
        /// A description of this recipe.</summary>
        public string Description { get; private set; }

        /// <summary>
        /// A list of key words for categorizing this recipe.</summary>
        public string KeyWords { get; private set; }

        /// <summary>
        /// The preparation time of this recipe or the total preperation time of all sections if this recipe has sections.</summary>
        public string PreparationTime { get; private set; }

        /// <summary>
        /// The cooking time of this recipe or the total cooking time of all sections if this recipe has sections.</summary>
        public string CookingTime { get; private set; }

        /// <summary>
        /// The sum of preparation time and cooking time.</summary>
        public string TotalTime { get; private set; }


        public String Servings { get; private set; }
        #endregion
    }
}
