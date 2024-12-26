using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class GameManager
    {
        public void StartGame()
        {
            
            while(true)
            {
                Console.WriteLine("게임을 시작 하려면 1번키, 종료하려면 0번 키를 누르세요");
                int inputNum = int.Parse(Console.ReadLine());
                if(inputNum == 0)
                {
                    Console.WriteLine("게임을 종료합니다");
                    break;
                }

                else if(inputNum == 1)
                {
                    Player player = new Player(10, 10, 10, 10);
                    MonsterManager monster = new MonsterManager();
                    Map map = new Map();
                    ShopNPC shopNPC = new ShopNPC();
                    HouseNPC houseNPC = new HouseNPC();
                    player.CreateInven();
                    player.CreatePlayerSkillSlot();
                    shopNPC.CreateShopInven();
                    shopNPC.AddShopItem();
                    ConsoleKeyInfo myKey = new ConsoleKeyInfo();
                    Console.CursorVisible = false;
                    while (true)
                    {
                        if(myKey.Key == ConsoleKey.I)
                        {
                            player.ShowPlayerInven();
                        }
                        else if(myKey.Key == ConsoleKey.C)
                        {
                            player.EquipmentSet();
                        }
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
                    }

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
