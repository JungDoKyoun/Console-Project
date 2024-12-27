using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    enum ItemType
    {
        Weapon, Armor, UsableHP, UsableMP
    }
    internal class Item
    {
        public string ItemName { get; set; }
        public int ItemEffect { get; set; }
        public ItemType ItemType { get; set; }
        public int ItemPrice { get; set; }

        public Item(string itemName, int itemEffect, int itemPrice,ItemType itemType)
        {
            ItemName = itemName;
            ItemEffect = itemEffect;
            ItemPrice = itemPrice;
            ItemType = itemType;
        }
    }
}
