using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class MonsterManager
    {
        public List<Monster> FirstMapNomalMonster { get; set; }
        static int _firstMapNomalMonsterCount = 0;
        Random random = new Random();

        public void SetMonster(Map map)
        {
            FirstMapNomalMonster = new List<Monster>();
            while (_firstMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(1, map.Size - 1);
                int PosY = random.Next(1, map.Size - 1);
                if (ran == 0)
                {
                    FirstMapNomalMonster.Add(new NomalMonster("슬라임", 1, 30, 0, 10, 3, 10, 100, PosX, PosY));
                    _firstMapNomalMonsterCount++;
                }
                else if (ran == 1)
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린", 1, 40, 0, 12, 0, 13, 120, PosX, PosY));
                    _firstMapNomalMonsterCount++;
                }
            }

        }

        public void PrintBattleMonsterInfo()
        {
            for(int i = 0; i < FirstMapNomalMonster.Count; i++)
            {
                Console.WriteLine($"{FirstMapNomalMonster[i].MonsterName}의 상태창");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"{FirstMapNomalMonster[i].MonsterName}의 HP : {FirstMapNomalMonster[i].MonsterHP}");
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}

