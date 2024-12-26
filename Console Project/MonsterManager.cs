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
        public List<Monster> FirstMapBossMonster { get; set;}
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
                else
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린", 1, 40, 0, 12, 0, 13, 120, PosX, PosY));
                    _firstMapNomalMonsterCount++;
                }
            }

        }

        public void SetBossMonster(Map map)
        {
            FirstMapBossMonster = new List<Monster>();
            FirstMapBossMonster.Add(new BossMonster("고블린 족장", 5, 100, 10, 20, 6, 25, 300, 8, 8));
        }

        public Monster ReturnMonster()
        {
            Monster monster = new NomalMonster();
            for(int i = 0; i < FirstMapNomalMonster.Count; i++)
            {
                monster = FirstMapNomalMonster[i];
            }
            return monster;
        }

        public Monster ReturnBossMonster()
        {
            Monster bossMonster = new BossMonster();
            for(int i = 0; i< FirstMapBossMonster.Count; i++)
            {
                bossMonster = FirstMapBossMonster[i];
            }
            return bossMonster;
        }
        public void PrintBattleMonsterInfo()
        {
            
                Console.WriteLine($"{ReturnMonster().MonsterName}의 상태창");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"{ReturnMonster().MonsterName}의 HP : {ReturnMonster().MonsterHP}");
                Console.WriteLine("--------------------------------------");
            
        }
    }
}

