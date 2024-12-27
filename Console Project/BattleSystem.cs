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
        bool isRun = false;
        bool isEnd = false;
        bool isNonSkill = false;
        ConsoleKeyInfo myKey = new ConsoleKeyInfo();
        PrintPicter print = new PrintPicter();
        
        public void NomalMonsterBattle(Player player, MonsterManager monster, Map map, int x, int y)
        {
            while(true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                if(monster.ReturnMonster(map, x, y).MonsterName == "슬라임")
                {
                    print.PrintSlime();
                }
                else if(monster.ReturnMonster(map, x, y).MonsterName == "고블린")
                {
                    print.PrintGoblin();
                }
                else if (monster.ReturnMonster(map, x, y).MonsterName == "고블린 전사")
                {
                    print.PrintWarGoblin();
                }
                else if (monster.ReturnMonster(map, x, y).MonsterName == "고블린 근위병")
                {
                    print.PrintEliteGoblin();
                }
                player.PrintBattlePlayerInfo();
                Console.WriteLine();
                monster.PrintBattleMonsterInfo(map, x, y);
                
                PlayerChooseAttack(player, monster.ReturnMonster(map, x, y));
                if (isRun == true)
                {
                    isRun = false;
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
                else if(isNonSkill == true)
                {
                    isNonSkill = false;
                    continue;
                }
                else if(monster.ReturnMonster(map, x, y).MonsterHP == 0 || monster.ReturnMonster(map, x, y).MonsterHP < 0)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    NomalMonsterBattleWin(player, monster.ReturnMonster(map, x, y));
                    map.TileTypes[monster.ReturnMonster(map, x, y).MonsterPosX, monster.ReturnMonster(map, x, y).MonsterPosY] = Map.TileType.Empty;
                    if(monster.ReturnMonster(map, x, y).MonsterPosX < 9)
                    {
                        MonsterManager._firstMapNomalMonsterCount--;
                        monster.RezenMonster(map);
                    }

                    else if (monster.ReturnMonster(map, x, y).MonsterPosX > 9)
                    {
                        MonsterManager._secondMapNomalMonsterCount--;
                        monster.RezenMonster(map);
                    }
                    monster.FirstMapNomalMonster.Remove(monster.ReturnMonster(map, x, y));
                    while(true)
                    { 
                        myKey = Console.ReadKey();
                        if(myKey.Key == ConsoleKey.Enter)
                        {
                            isEnd = true;
                            Console.Clear();
                            break;
                        }
                    }
                if(isEnd == true)
                {
                    isEnd = false;
                    break;
                }
                    
                }
                Thread.Sleep(1000);
                Console.Clear();

                NomalMonsterAttackPlayer(player, monster.ReturnMonster(map, x, y));
                if(PlayerLoss(player) == true)
                {
                    Console.WriteLine("당신은 죽었습니다");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
            }
        }

        public void BossMonsterBattle(Player player, MonsterManager monster)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                print.PrintBossGoblin();
                player.PrintBattlePlayerInfo();
                Console.WriteLine();
                monster.PrintBattleBossMonsterInfo();
                PlayerChooseAttack(player, monster.ReturnBossMonster());
                
                if (isRun == true)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
                else if (monster.ReturnBossMonster().MonsterHP == 0 || monster.ReturnBossMonster().MonsterHP < 0)
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    BossMonsterBattleWin(player, monster.ReturnBossMonster());
                    monster.FirstMapBossMonster.Remove(monster.ReturnBossMonster());
                    while (true)
                    {
                        myKey = Console.ReadKey();
                        if (myKey.Key == ConsoleKey.Enter)
                        {
                            isEnd = true;
                            Console.Clear();
                            break;
                        }
                    }
                }
                if (isEnd == true)
                {
                    isEnd = false;
                    break;
                }
                Thread.Sleep(1000);
                Console.Clear();

                BossMonsterAttack(player, monster);
                if (PlayerLoss(player) == true)
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
                        Console.Clear();
                        Console.WriteLine("도망에 성공했습니다");
                        isRun = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("도망에 실패했습니다");
                        continue;
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
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"{monster.MonsterName}을 공격하였다!!");
            monster.MonsterHP -= player.Damage - monster.MonsterDefensivePower;
            Console.WriteLine($"{monster.MonsterName}에게 {player.Damage - monster.MonsterDefensivePower}만큼의 피해를 입혔습니다");
        }

        public void PlayerUseSkill(Player player, Monster monster)
        {
            Thread.Sleep(1000);
            Console.Clear();
            while (true)
            {
                if (player.PlayerSkills.Count == 0)
                {
                    Console.WriteLine("사용 할 수 있는 스킬이 없습니다");
                    isNonSkill = true;
                    break;
                }
                
                Console.WriteLine("사용할 스킬을 선택하세요 (0번을 누르면 이전 화면으로 넘어갑니다)");
                Console.WriteLine();
                player.PrintPlayerSkill();
                Console.WriteLine();
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);

                if(isCorrect == false)
                {
                    continue;
                }
                else if(inputNum == 0)
                {
                    break;
                }
                else if (inputNum == 1 && player.PlayerSkills[0] != null)
                {
                    if(player.MP >= player.PlayerSkills[0].SkillMP)
                    {
                        player.PlayerSkills[0].SkillAttack(player, monster);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("마나가 모자랍니다");
                    }
                    
                }
                else if (inputNum == 2 && player.PlayerSkills[1] != null)
                {
                    if (player.MP >= player.PlayerSkills[1].SkillMP)
                    {
                        player.PlayerSkills[1].SkillAttack(player, monster);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("마나가 모자랍니다");
                    }
                }
                else if (inputNum == 3 && player.PlayerSkills[2] != null)
                {
                    if (player.MP >= player.PlayerSkills[2].SkillMP)
                    {
                        player.PlayerSkills[2].SkillAttack(player, monster);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("마나가 모자랍니다");
                    }
                }
                
            }
        }

        public void NomalMonsterAttackPlayer(Player player, Monster monster )
        {
            Console.WriteLine($"{monster.MonsterName}의 공격!!");
            player.HP -= monster.MonsterDamage - player.DefensivePower;
            Console.WriteLine($"{monster.MonsterName}가 {monster.MonsterDamage - player.DefensivePower}만큼의 데미지를 플레이어에게 입혔습니다");
        }

        public void NomalMonsterBattleWin(Player player, Monster monster)
        {
            if(monster.MonsterHP == 0 || monster.MonsterHP < 0)
            {
                monster.MonsterHP = 0;
                player.PlayerExp += monster.MonsterGiveExp;
                player.PlayerMoney += monster.MonsterGiveMoney;
                Console.WriteLine($"{monster.MonsterName}과의 싸움에서 승리하였습니다!!");
                Console.WriteLine($"{monster.MonsterGiveExp}만큼의 경험치와 {monster.MonsterGiveMoney}만큼의 돈을 획득하였습니다");
                player.PlayerLveleUp();
                Console.WriteLine($"현재 레벨 : {player.PlayerLevel}\t현재 경험치 : {player.PlayerExp}\t현재 돈 : {player.PlayerMoney}");
                Console.WriteLine("엔터를 누르면 진행됩니다");

            }
        }
        public void BossMonsterBattleWin(Player player, Monster monster)
        {
            if (monster.MonsterHP == 0 || monster.MonsterHP < 0)
            {
                monster.MonsterHP = 0;
                BossDie(monster);
                player.PlayerExp += monster.MonsterGiveExp;
                player.PlayerMoney += monster.MonsterGiveMoney;
                Console.WriteLine($"{monster.MonsterName}과의 싸움에서 승리하였습니다!!");
                Console.WriteLine($"{monster.MonsterGiveExp}만큼의 경험치와 {monster.MonsterGiveMoney}만큼의 돈을 획득하였습니다");
                Console.WriteLine("엔터를 누르면 진행됩니다");

            }
        }

        public void BossMonsterAttack(Player player, MonsterManager monster)
        {
            Random random = new Random();
            int Num = random.Next(0, 4);
            if(Num == 0)
            {
                if (monster.FirstMapBossMonster[0].MonsterMP >= monster.BossSkill[0].SkillMP)
                {
                    Console.WriteLine("파이어볼 사용");
                    monster.BossSkill[0].SkillAttack(player, monster.ReturnBossMonster());
                }
                else
                {
                    NomalMonsterAttackPlayer(player, monster.ReturnBossMonster());
                }
            }
            else
            {
                NomalMonsterAttackPlayer(player, monster.ReturnBossMonster());
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

        public bool BossDie(Monster monster)
        {
            if(monster.MonsterHP == 0 || monster.MonsterHP < 0)
            {
                return true;
            }
            return false;
        }
    }
}
