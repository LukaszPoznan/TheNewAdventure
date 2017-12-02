using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        public Item Details { get; set; }
        public int DropPer { get; set; }
        public bool IsDefaultItem { get; set; }
        public int Gold { get; set; }

        public LootItem(Item details, int dropPer, bool isDefaultItem, int gold)
        {
            Details = details;
            DropPer = dropPer;
            IsDefaultItem = isDefaultItem;
            Gold = gold;
        }
    }
}
