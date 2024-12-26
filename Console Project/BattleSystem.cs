using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class BattleSystem
    {
        public void PlayerChooseAttack(Player player, Monster monster)
        {
            while(true)
            {
                Console.WriteLine($"{monster.MonsterName}을 만났다!!!");
                Console.WriteLine("취할 행동을 선택하여 주세요");
                Console.WriteLine("1. 일반공격\t2. 스킬사용\t3. 아이템사용\t4. 도주");
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);

                //if (isCorrect != true || inputNum > 4 || inputNum < 1)
                //{
                //    Console.WriteLine($"{monster.MonsterName}을 만났다!!!");
                //    Console.WriteLine("취할 행동을 선택하여 주세요");
                //    Console.WriteLine("1. 일반공격\t2. 스킬사용\t3. 아이템사용\t4. 도주");
                //    isCorrect = int.TryParse(Console.ReadLine(), out inputNum);
                //    Thread.Sleep(1000);
                //    Console.Clear();
                //}

                if(inputNum == 1)
                {
                    PlayerAttackMonster(player, monster);
                }
                else if(inputNum == 2)
                {
                    break;
                }
                else if (inputNum == 3)
                {
                    break;
                }
                else if (inputNum == 4)
                {
                    break;
                }
                else
                {
                    continue;
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
            
        }
        public void PlayerAttackMonster(Player player, Monster monster)
        {
            Console.WriteLine($"{monster.MonsterName}을 공격하였다!!");
            monster.MonsterHP -= player.Damage - monster.MonsterDefensivePower;
            Console.WriteLine($"{monster.MonsterName}에게 {player.Damage}만큼의 피해를 입혀 체력 {monster.MonsterHP}이 남았습니다");
        }

        public void PlayerUseSkill(Player player, Monster monster)
        {
            while(true)
            {
                Console.WriteLine("사용할 스킬을 선택하세요");
                Console.WriteLine();
                player.PrintPlayerSkill();
                Console.WriteLine();
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);

                if(player.PlayerSkill.Count == 0)
                {
                    Console.WriteLine("사용 할 수 있는 스킬이 없습니다");
                    break;
                }
                else if(player.PlayerSkill.Count == 1)
                {
                    if(inputNum == 1)
                    {
                        Console.WriteLine("강타를 사용합니다");
                        monster.MonsterHP -= (player.Damage * 2) - monster.MonsterDefensivePower;
                        break;
                    }
                }
                else if(player.PlayerSkill.Count == 2)
                {
                    if (inputNum == 1)
                    {
                        Console.WriteLine("강타를 사용합니다");
                        monster.MonsterHP -= (player.Damage * 2) - monster.MonsterDefensivePower;
                    }
                    else if(inputNum ==2)
                }

            }
        }
    }
}
