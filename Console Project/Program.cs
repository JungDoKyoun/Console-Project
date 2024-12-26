using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GameManager gameManager = new GameManager();
            //gameManager.StartGame();
            Player myPlayer = new Player(10, 10, 10, 10);
            MonsterManager monster = new MonsterManager();
            Map map = new Map();
            ShopNPC shopNPC = new ShopNPC();
            NPC[] npc = new NPC[] { shopNPC };
            ConsoleKeyInfo inputKey;
            map.Initialize(10);
            myPlayer.SetPlayerPos();
            monster.SetMonster(map);
            monster.SetBossMonster(map);
            Console.CursorVisible = false;
            myPlayer.CreateInven();
            myPlayer.CreatePlayerSkillSlot();
            BattleSystem battle = new BattleSystem();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    inputKey = Console.ReadKey(true);
                    if (inputKey.Key == ConsoleKey.UpArrow)
                    {
                        myPlayer.MoveForward(map, battle, monster, myPlayer);
                    }
                    else if (inputKey.Key == ConsoleKey.DownArrow)
                    {
                        myPlayer.MoveBackward(map, battle, monster, myPlayer);
                    }
                    else if (inputKey.Key == ConsoleKey.RightArrow)
                    {
                        myPlayer.MoveRight(map, battle, monster, myPlayer);
                    }
                    else if (inputKey.Key == ConsoleKey.LeftArrow)
                    {
                        myPlayer.MoveLeft(map, battle, monster, myPlayer);
                    }
                }
                map.Render(myPlayer, monster);

            }
            battle.NomalMonsterBattle(myPlayer, monster);
        }
    }
}
