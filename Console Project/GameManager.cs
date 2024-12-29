using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class GameManager
    {
        public void StartGame()
        {
            Console.SetWindowSize(100, 35);
            Player player = new Player(1, 100, 200, 5);
            Map map = new Map();
            MonsterManager monster = new MonsterManager();
            ShopNPC shopNPC = new ShopNPC();
            HouseNPC houseNPC = new HouseNPC();
            BattleSystem battleSystem = new BattleSystem();
            PrintPicter pic = new PrintPicter();
            player.CreateInven();
            player.CreatePlayerSkillSlot();
            shopNPC.CreateShopInven();
            shopNPC.AddShopItem();
            ConsoleKeyInfo myKey = new ConsoleKeyInfo();
            Console.CursorVisible = false;
            map.Initialize(20, 10);
            player.SetPlayerPos();
            monster.SetBossMonster(map);
            monster.SetBossSkillSlot(monster.ReturnBossMonster());
            monster.SetMonster(map);
            bool isOpeningEnd = false;
            while (true)
            {
                Console.Title = "우리 마을 앞에 고블린 부락이 생겼다";
                pic.PrintTitle();
                Console.WriteLine();
                Console.WriteLine("게임을 시작 하려면 1번키, 종료하려면 0번 키를 누르세요");
                bool isStart = int.TryParse(Console.ReadLine(), out int inputNum);
                
                if(isStart == false)
                {
                    Console.Clear();
                    continue;
                }
                else if (inputNum == 0)
                {
                    Console.WriteLine("게임을 종료합니다");
                    break;
                }

                else if (inputNum == 1)
                {
                    while(isOpeningEnd == false)
                    {
                        Console.Clear();
                        Console.WriteLine("어느날 갑자기 마을 앞에 고블린 부락이 생겼다");
                        Console.WriteLine();
                        Console.WriteLine("마을의 청년 한스는 위험에 처한 마을을 구하기 위하여 고블린 부락을 소탕하기로 하는데....");
                        Console.WriteLine();
                        Console.WriteLine("엔터를 누르면 진행합니다");
                        myKey = Console.ReadKey();
                        if(myKey.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            continue;
                        }
                    }
                    

                    while (true)
                    {
                        if (battleSystem.PlayerLoss(player) == true)
                        {
                            break;
                        }
                        if (battleSystem.BossDie(monster.ReturnBossMonster()) == true)
                        {
                            break;
                        }
                        Console.Clear();
                        player.PrintPlayerSimpleInfo();
                        Console.WriteLine();
                        Console.WriteLine("현재 위치는 마을입니다 갈 곳을 선택해 주세요");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("1. 집\t2. 상점\t3. 사냥터");
                        inputNum = int.Parse(Console.ReadLine());

                        if (inputNum == 0)
                        {
                            break;
                        }
                        if (inputNum == 1)
                        {
                            houseNPC.Interact(player);
                        }
                        else if (inputNum == 2)
                        {
                            shopNPC.Interact(player);
                        }

                        else if (inputNum == 3)
                        {
                            Console.Clear();

                            while (true)
                            {
                                if (Console.KeyAvailable)
                                {
                                    myKey = Console.ReadKey(true);
                                    if (myKey.Key == ConsoleKey.DownArrow)
                                    {
                                        player.MoveForward(map, battleSystem, monster, player);
                                    }
                                    else if (myKey.Key == ConsoleKey.UpArrow)
                                    {
                                        player.MoveBackward(map, battleSystem, monster, player);
                                    }
                                    else if (myKey.Key == ConsoleKey.RightArrow)
                                    {
                                        player.MoveRight(map, battleSystem, monster, player);
                                    }
                                    else if (myKey.Key == ConsoleKey.LeftArrow)
                                    {
                                        player.MoveLeft(map, battleSystem, monster, player);
                                    }
                                    else if (myKey.Key == ConsoleKey.I)
                                    {
                                        Console.Clear();
                                        player.EquipmentSet();
                                    }
                                    else if (myKey.Key == ConsoleKey.C)
                                    {
                                        Console.Clear();
                                        player.PrintBattleMapPlayerInfo();
                                    }
                                }
                                if (battleSystem.PlayerLoss(player) == true)
                                {
                                    break;
                                }
                                if (battleSystem.BossDie(monster.ReturnBossMonster()) == true)
                                {
                                    break;
                                }
                                if (player.IsHome == true)
                                {
                                    player.IsHome = false;
                                    break;
                                }

                                map.Render(player, monster);
                            }
                        }
                        if (battleSystem.BossDie(monster.ReturnBossMonster()) == true)
                        {
                            pic.PrintWin();
                            Console.WriteLine("고블린 부락을 없애 마을에 평화를 지켰습니다");
                            Console.WriteLine("엔터를 누르면 메인메뉴로 돌아갑니다");
                            while(true)
                            {
                                myKey = Console.ReadKey(true);
                                if (myKey.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    continue;
                }
                
            }



        }
    }
}
