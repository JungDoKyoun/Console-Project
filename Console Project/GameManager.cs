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
            
            while(true)
            {
                Player player = new Player(10, 10, 1000, 10);
                MonsterManager monster = new MonsterManager();
                Map map = new Map();
                ShopNPC shopNPC = new ShopNPC();
                HouseNPC houseNPC = new HouseNPC();
                BattleSystem battleSystem = new BattleSystem();
                player.CreateInven();
                player.CreatePlayerSkillSlot();
                shopNPC.CreateShopInven();
                shopNPC.AddShopItem();
                ConsoleKeyInfo myKey = new ConsoleKeyInfo();
                Console.CursorVisible = false;
                map.Initialize(10, 20);
                player.SetPlayerPos();
                monster.SetMonster(map);
                monster.SetBossMonster(map);
                monster.SetBossSkillSlot(monster.ReturnBossMonster());

                Console.WriteLine("게임을 시작 하려면 1번키, 종료하려면 0번 키를 누르세요");
                int inputNum = int.Parse(Console.ReadLine());
                if(inputNum == 0)
                {
                    Console.WriteLine("게임을 종료합니다");
                    break;
                }

                else if(inputNum == 1)
                {
                    
                    while (true)
                    {
                        if(battleSystem.PlayerLoss(player)== true)
                        {
                            break;
                        }
                        if (battleSystem.BossDie(monster.ReturnBossMonster()) == true)
                        {
                            break;
                        }
                        Console.Clear();
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
                        else if(inputNum == 2)
                        {
                            shopNPC.Interact(player);
                        }

                        else if( inputNum == 3)
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
                                }
                                if (battleSystem.PlayerLoss(player) == true)
                                {
                                    break;
                                }
                                if(battleSystem.BossDie(monster.ReturnBossMonster())== true)
                                {
                                    break; 
                                }
                                if(player.IsHome == true)
                                {
                                    player.IsHome = false;
                                    break;
                                }
                                

                                map.Render(player, monster);
                            }
                        }
                    }
                    
                }
                if (battleSystem.BossDie(monster.ReturnBossMonster()) == true)
                {
                    Console.WriteLine("고블린 부락을 없애 마을에 평화를 지켰습니다");
                    break;
                }
            }

            

        }
        
        
        //while (true)
        //{
        //    if (Console.KeyAvailable) 
        //    {
        //        inputKey = Console.ReadKey(true);
        //        if (inputKey.Key == ConsoleKey.UpArrow)
        //        {
        //            myPlayer.MoveForward(map);
        //        }
        //        else if(inputKey.Key == ConsoleKey.DownArrow)
        //        {
        //            myPlayer.MoveBackward(map);
        //        }
        //        else if(inputKey.Key == ConsoleKey.RightArrow)
        //        {
        //            myPlayer.MoveRight(map);
        //        }
        //        else if (inputKey.Key == ConsoleKey.LeftArrow)
        //        {
        //            myPlayer.MoveLeft(map);
        //        }
        //        monster.SetMonster(map);
        //        map.Render(myPlayer, monster);
        //    }

        //}
        
    }
}
