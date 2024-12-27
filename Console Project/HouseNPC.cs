using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class HouseNPC : NPC
    {
        public HouseNPC()
        {
            NPCName = "엄마";
        }
        public override void Interact(Player player)
        {
            while(true)
            {
                Console.Clear();
                player.PrintPlayerInfo();
                Console.WriteLine($"{NPCName} : 어서오렴 오늘은 쉬겠니??");
                Console.WriteLine("1. 쉰다\n2. 장비를 바꾼다\n3. 나간다");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                if(isCorrect == false)
                {
                    continue;
                }
                if (inputNum == 1)
                {
                    Console.WriteLine("침대에서 잠을 잤다");
                    Console.WriteLine("체력및 마나 전부 회복");
                    player.HP += 100;
                    player.MP += 100;
                    Thread.Sleep(1000);
                    Console.Clear();

                }
                else if (inputNum == 2)
                {
                    player.EquipmentSet();
                }
                else if (inputNum == 3)
                {
                    Console.WriteLine("잘 갔다오렴");
                    break;
                }
                else
                {
                    continue;
                }
            }
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}
