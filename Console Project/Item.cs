using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    enum ItemType
    {
        Weapon, Armor, Usable
    }
    internal class Item
    {
        public string ItemName { get; set; }
        public int ItemEffect { get; set; }
        public ItemType ItemType { get; set; }

        public Item(string itemName, int itemEffect, ItemType itemType)
        {
            ItemName = itemName;
            ItemEffect = itemEffect;
            ItemType = itemType;
        }
    }
}
