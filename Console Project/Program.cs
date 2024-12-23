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
            ConsoleKeyInfo temp;
            while (true)
            {
                map.Initialize(10);
                myPlayer.SetPlayerPos();
                if (Console.KeyAvailable) //키가 눌렸을때만 돌게 됨
                {
                    temp = Console.ReadKey(true);
                    if (temp.Key == ConsoleKey.W)
                    {
                        myPlayer.MoveForward(map);
                    }
                }
                map.Render(myPlayer);
            }
        }
    }
}
