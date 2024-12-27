using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class MonsterManager
    {
        public List<Monster> FirstMapNomalMonster { get; set; }
        public List<Monster> FirstMapBossMonster { get; set;}
        public List<Skill> BossSkill { get; set; }
        static int _firstMapNomalMonsterCount = 0;
        static int _secondMapNomalMonsterCount = 0;

        Random random = new Random();

        public void SetMonster(Map map)
        {
            FirstMapNomalMonster = new List<Monster>();
            while (_firstMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(1, 9);
                int PosY = random.Next(1, 9);
                if (ran == 0)
                {
                    FirstMapNomalMonster.Add(new NomalMonster("슬라임", 1, 30, 0, 10, 3, 10, 100, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _firstMapNomalMonsterCount++;
                    
                }
                else
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린", 1, 40, 0, 12, 0, 13, 120, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _firstMapNomalMonsterCount++;
                }
            }
            while (_secondMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(11, 19);
                int PosY = random.Next(1, 9);
                if (ran == 0)
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린 전사", 10, 80, 0, 20, 10, 25, 400, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _secondMapNomalMonsterCount++;

                }
                else
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린 근위병", 15, 150, 0, 30, 15, 40, 600, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _secondMapNomalMonsterCount++;
                }
            }

        }

        public void RezenMonster(Map map)
        {
            _firstMapNomalMonsterCount--;
            while (_firstMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(1, 9);
                int PosY = random.Next(1, 9);
                if (ran == 0)
                {
                    FirstMapNomalMonster.Add(new NomalMonster("슬라임", 1, 30, 0, 10, 3, 10, 100, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _firstMapNomalMonsterCount++;

                }
                else
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린", 1, 40, 0, 12, 0, 13, 120, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _firstMapNomalMonsterCount++;
                }
            }
            _secondMapNomalMonsterCount--;
            while (_secondMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(11, 19);
                int PosY = random.Next(1, 9);
                if (ran == 0)
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린 전사", 10, 80, 0, 20, 10, 25, 400, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _secondMapNomalMonsterCount++;

                }
                else
                {
                    FirstMapNomalMonster.Add(new NomalMonster("고블린 근위병", 15, 150, 0, 30, 15, 40, 600, PosX, PosY, MonsterSkill.non));
                    map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                    _secondMapNomalMonsterCount++;
                }
            }

        }

        public void SetBossMonster(Map map)
        {
            FirstMapBossMonster = new List<Monster>();
            FirstMapBossMonster.Add(new BossMonster("고블린 족장", 20, 100, 10, 20, 6, 25, 300, 18, 8, MonsterSkill.FireBall));
            map.TileTypes[18, 8] = Map.TileType.BossMonster;
        }
        public void SetBossSkillSlot(Monster monster)
        {
            BossSkill = new List<Skill> { new FireBall("파이어볼", "공격력 2배 데미지", monster.MonsterDamage * 2, 5) };
        }
        

        public Monster ReturnMonster(Map map)
        {
            Monster monster = new NomalMonster();
            for(int y = 0; y < map.Size2; y++)
            {
                for(int x  = 0; x < map.Size1; x++)
                {
                    if (map.TileTypes[y, x] == Map.TileType.Monster)
                    {
                        for (int i = 0; i < FirstMapNomalMonster.Count; i++)
                        {
                            if (y == FirstMapNomalMonster[i].MonsterPosX && x == FirstMapNomalMonster[i].MonsterPosY)
                            {
                                monster = FirstMapNomalMonster[i];
                            }
                        }
                    }
                    
                }
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
        
        public void PrintBattleMonsterInfo(Map map)
        {
            
                Console.WriteLine($"{ReturnMonster(map).MonsterName}의 상태창");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"{ReturnMonster(map).MonsterName}의 HP : {ReturnMonster(map).MonsterHP}");
                Console.WriteLine("--------------------------------------");
            
        }
        public void PrintBattleBossMonsterInfo()
        {

            Console.WriteLine($"{ReturnBossMonster().MonsterName}의 상태창");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{ReturnBossMonster().MonsterName}의 HP : {ReturnBossMonster().MonsterHP}");
            Console.WriteLine("--------------------------------------");

        }
    }
}

