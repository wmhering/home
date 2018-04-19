using System;
using System.Collections.Generic;
using System.Text;

namespace Home.BO
{
    public class MenuEditor
    {
        private List<Item> _Items = new List<Item>();

        public List<Item> Items
        {
            get { return _Items; }
        }

        public class Item
        {
            public string Description { get; set; }
            public bool Prepared { get; set; }
        }
    }
}
