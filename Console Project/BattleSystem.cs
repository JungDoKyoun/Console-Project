﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class BattleSystem
    {
        bool isRun = false;
        
        public void NomalMonsterBattle(Player player, MonsterManager monster)
        {
            while(true)
            {
                player.PrintBattlePlayerInfo();
                Console.WriteLine();
                monster.PrintBattleMonsterInfo();
                PlayerChooseAttack(player, monster.ReturnMonster());
                if(isRun == true)
                {
                    break;
                }
                else if(monster.ReturnMonster().MonsterHP == 0 || monster.ReturnMonster().MonsterHP < 0)
                {
                    NomalMonsterBattleWin(player, monster.ReturnMonster());
                    monster.FirstMapNomalMonster.Remove(monster.ReturnMonster());
                    break;
                }
                Thread.Sleep(1000);
                Console.Clear();

                NomalMonsterAttackPlayer(player, monster.ReturnMonster());
                if(PlayerLoss(player) == true)
                {
                    Console.WriteLine("당신은 죽었습니다");
                    break;
                }
            }
            

        }
        public void PlayerChooseAttack(Player player, Monster monster)
        {
            while(true)
            {
                Console.WriteLine($"{monster.MonsterName}을 만났다!!!");
                Console.WriteLine();
                Console.WriteLine("행동을 선택하여 주세요");
                Console.WriteLine();
                Console.WriteLine("1. 일반공격\t2. 스킬사용\t3. 아이템사용\t4. 도주");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);

                if(inputNum == 1)
                {
                    PlayerAttackMonster(player, monster);
                    break;
                }
                else if(inputNum == 2)
                {
                    PlayerUseSkill(player, monster);
                    break;
                }
                else if (inputNum == 3)
                {
                    player.UseUsableItem();
                    break;
                }
                else if (inputNum == 4)
                {
                    Random random = new Random();
                    int Num = random.Next(0, 2);
                    if (Num == 0)
                    {
                        Console.WriteLine("도망에 성공했습니다");
                        isRun = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망에 실패했습니다");
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            
        }
        public void PlayerAttackMonster(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.MonsterName}을 공격하였다!!");
            monster.MonsterHP -= player.Damage - monster.MonsterDefensivePower;
            Console.WriteLine($"{monster.MonsterName}에게 {player.Damage - monster.MonsterDefensivePower}만큼의 피해를 입혀 체력 {monster.MonsterHP}이 남았습니다");
        }

        public void PlayerUseSkill(Player player, Monster monster)
        {
            while(true)
            {
                if (player.PlayerSkills.Count == 0)
                {
                    Console.WriteLine("사용 할 수 있는 스킬이 없습니다");
                    break;
                }
                Console.WriteLine("사용할 스킬을 선택하세요 (0번을 누르면 이전 화면으로 넘어갑니다)");
                Console.WriteLine();
                player.PrintPlayerSkill();
                Console.WriteLine();
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);

                if(inputNum == 0)
                {
                    break;
                }
                else if (inputNum == 1 && player.PlayerSkills[0] != null)
                {
                    player.PlayerSkills[0].SkillAttack(player, monster);
                    break;
                }
                else if (inputNum == 2 && player.PlayerSkills[1] != null)
                {
                    player.PlayerSkills[1].SkillAttack(player, monster);
                    break;
                }
                else if (inputNum == 3 && player.PlayerSkills[2] != null)
                {
                    player.PlayerSkills[2].SkillAttack(player, monster);
                    break;
                }
                
            }
        }

        public void NomalMonsterAttackPlayer(Player player, Monster monster )
        {
            Console.WriteLine($"{monster.MonsterName}의 공격!!");
            player.HP -= monster.MonsterDamage - player.DefensivePower;
            Console.WriteLine($"{monster.MonsterName}가 {monster.MonsterDamage - player.DefensivePower}만큼의 데미지를 플레이어에게 입혀 {player.HP}만큼의 HP가 남았습니다");
        }

        public void NomalMonsterBattleWin(Player player, Monster monster)
        {
            if(monster.MonsterHP == 0 || monster.MonsterHP < 0)
            {
                monster.MonsterMP = 0;
                player.PlayerExp += monster.MonsterGiveExp;
                player.PlayerMoney += monster.MonsterGiveMoney;
                Console.WriteLine($"{monster.MonsterName}과의 싸움에서 승리하였습니다!!");
                Console.WriteLine($"{monster.MonsterGiveExp}만큼의 경험치와 {monster.MonsterGiveMoney}만큼의 돈을 획득하였습니다");
                
            }
        }

        public bool PlayerLoss(Player player)
        {
            if(player.HP == 0 || player.HP < 0)
            {
                return true;
            }
            return false;
        }
    }
}
