using System.Collections.Generic;

namespace Home.BO
{
    public class ShoppingListEditor
    {
        private List<Item> _Items = new List<Item>();

        public List<Item> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public class Item
        {
            public decimal Quantity { get; set; }
            public string Description { get; set; }
            public bool Purchased { get; set; }
        }
    }
}
