using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class NomalMonster : Monster
    {
        Random random = new Random();
        List<Monster> firstMapMonsters;
        static int _nomalMonsterCount = 0;
        public NomalMonster()
        {

        }
        public NomalMonster(string name, int level, int HP, int MP, int damage, int Def, int exp, int money) : base(name, level, HP, MP, damage, Def, exp, money)
        {
        }

        public override void SetMonster(Map map)
        {
            firstMapMonsters = new List<Monster>();
            while(_nomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                if (ran == 0)
                {
                    firstMapMonsters.Add(new NomalMonster("슬라임", 1, 30, 0, 10, 3, 10, 100));
                    MonsterPosX = random.Next(1, map.Size - 1);
                    MonsterPosY = random.Next(1, map.Size - 1);
                    _nomalMonsterCount++;
                }
                else if (ran == 1)
                {
                    firstMapMonsters.Add(new NomalMonster("고블린", 1, 40, 0, 12, 0, 13, 120));
                    MonsterPosX = random.Next(1, map.Size - 1);
                    MonsterPosY = random.Next(1, map.Size - 1);
                    _nomalMonsterCount++;
                }
            }
            
        }

        public override void PrintBattleMonsterInfo()
        {
            Console.WriteLine($"{MonsterName}의 상태창");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{MonsterName}의 HP : {MonsterHP}\t{MonsterName}의 MP : {MonsterMP}");
            Console.WriteLine("--------------------------------------");
        }
    }
}
