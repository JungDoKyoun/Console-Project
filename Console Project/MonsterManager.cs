﻿using System;
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
        public static int _firstMapNomalMonsterCount = 0;
        public static int _secondMapNomalMonsterCount = 0;

        Random random = new Random();

        public void SetMonster(Map map)
        {
            FirstMapNomalMonster = new List<Monster>();
            while (_firstMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(1, 9);
                int PosY = random.Next(1, 9);
                if (map.TileTypes[PosX, PosY] == Map.TileType.Empty)
                {
                    if (ran == 0)
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("슬라임", 1, 60, 0, 10, 3, 10, 100, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _firstMapNomalMonsterCount++;

                    }
                    else
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("고블린", 1, 80, 0, 12, 0, 13, 120, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _firstMapNomalMonsterCount++;
                    }
                }
                
            }
            while (_secondMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(11, 19);
                int PosY = random.Next(1, 9);
                if (map.TileTypes[PosX, PosY] == Map.TileType.Empty)
                {
                    if (ran == 0)
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("고블린 전사", 10, 150, 0, 20, 10, 25, 400, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _secondMapNomalMonsterCount++;

                    }
                    else
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("고블린 근위병", 15, 200, 0, 30, 15, 40, 600, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _secondMapNomalMonsterCount++;
                    }
                }
                    
            }

        }
        
        public void RezenMonster(Map map)
        {
            
            while (_firstMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(1, 9);
                int PosY = random.Next(1, 9);
                if (map.TileTypes[PosX, PosY] == Map.TileType.Empty)
                {
                    if (ran == 0)
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("슬라임", 1, 60, 0, 10, 3, 10, 100, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _firstMapNomalMonsterCount++;

                    }
                    else
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("고블린", 1, 80, 0, 12, 0, 13, 120, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _firstMapNomalMonsterCount++;
                    }
                }
            }
            
            while (_secondMapNomalMonsterCount < 3)
            {
                int ran = random.Next(0, 2);
                int PosX = random.Next(11, 19);
                int PosY = random.Next(1, 9);
                if (map.TileTypes[PosX, PosY] == Map.TileType.Empty)
                {
                    if (ran == 0)
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("고블린 전사", 10, 150, 0, 20, 10, 25, 400, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _secondMapNomalMonsterCount++;

                    }
                    else
                    {
                        FirstMapNomalMonster.Add(new NomalMonster("고블린 근위병", 15, 200, 0, 25, 15, 40, 600, PosX, PosY, MonsterSkill.non));
                        map.TileTypes[PosX, PosY] = Map.TileType.Monster;
                        _secondMapNomalMonsterCount++;
                    }
                }
            }

        }

        public void SetBossMonster(Map map)
        {
            FirstMapBossMonster = new List<Monster>();
            FirstMapBossMonster.Add(new BossMonster("고블린 족장", 20, 500, 100, 35, 30, 70, 1500, 18, 8, MonsterSkill.FireBall));
            map.TileTypes[18, 8] = Map.TileType.BossMonster;
        }
        public void SetBossSkillSlot(Monster monster)
        {
            BossSkill = new List<Skill> { new FireBall("파이어볼", "공격력 2배 데미지", monster.MonsterDamage * 2, 5) };
        }
        

        public Monster ReturnMonster(Map map, int x, int y)
        {
            Monster monster = new NomalMonster();
           
            for (int i = 0; i < FirstMapNomalMonster.Count; i++)
            {
                if (x == FirstMapNomalMonster[i].MonsterPosX && y == FirstMapNomalMonster[i].MonsterPosY)
                {
                    monster = FirstMapNomalMonster[i];
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
        
        public void PrintBattleMonsterInfo(Map map, int x, int y)
        {
            
                Console.WriteLine($"{ReturnMonster(map, x ,y).MonsterName}의 상태창");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"{ReturnMonster(map, x, y).MonsterName}의 HP : {ReturnMonster(map, x, y).MonsterHP}");
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

