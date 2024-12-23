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
            Player myPlayer = new Player(10, 10, 10, 10);
            ShopNPC shopNPC = new ShopNPC();
            NPC[] npc = new NPC[] { shopNPC };
            Map map = new Map();
            map.Initialize(10);
            myPlayer.SetPlayerPos();
            map.Render(myPlayer);
        }
    }
}
