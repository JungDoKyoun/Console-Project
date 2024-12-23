using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player myPlayer = new Player(10, 10, 10, 10, 0);
            ShopNPC shopNPC = new ShopNPC();
            NPC[] npc = new NPC[] { shopNPC };
            myPlayer.CreateInven();
            shopNPC.CreateShopInven();
            shopNPC.AddShopItem();
            shopNPC.Interact(myPlayer);
            myPlayer.ShowPlayerInven();
            myPlayer.EquipmentSet();
        }
    }
}
