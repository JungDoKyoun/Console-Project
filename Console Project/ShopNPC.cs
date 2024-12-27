using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class ShopNPC : NPC, IInteract
    {
        List<Item> ShopItems;
        ConsoleKeyInfo keyInfo;
        public ShopNPC()
        {
            NPCName = "상점 상인";
        }

        public void CreateShopInven()
        {
            ShopItems = new List<Item>();
        }
        public void AddShopItem()
        {
            ShopItems.Add(new Item("장검", 20, 200 ,ItemType.Weapon));
        }

        public void ShowShopItem()
        {
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < ShopItems.Count; i++)
            {
                if (ShopItems[i].ItemType == ItemType.Weapon)
                {
                    Console.WriteLine($"{i + 1}. {ShopItems[i].ItemName}\t공격력 : {ShopItems[i].ItemEffect}\t아이템 가격 : {ShopItems[i].ItemPrice}\t아이템 타입 : 무기");
                }
                else if(ShopItems[i].ItemType == ItemType.Armor)
                {
                    Console.WriteLine($"{i + 1}. {ShopItems[i].ItemName}\t방어력 : {ShopItems[i].ItemEffect}\t아이템 가격 : {ShopItems[i].ItemPrice}\t아이템 타입 : 방어구");
                }
                else if (ShopItems[i].ItemType == ItemType.UsableHP)
                {
                    Console.WriteLine($"[{i + 1}]. {ShopItems[i].ItemName}\t회복력 : {ShopItems[i].ItemEffect}\t아이템 가격 : {ShopItems[i].ItemPrice}\t아이템 타입 : 물약");
                }
                else if (ShopItems[i].ItemType == ItemType.UsableMP)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {ShopItems[i].ItemName}\t회복력: {ShopItems[i].ItemEffect}\t아이템 가격 : {ShopItems[i].ItemPrice}\t아이템 종류: 물약");
                }
            }
            Console.WriteLine("--------------------------------------");
        }

        public override void Interact(Player player)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("어서 오세요 무엇을 하시겠습니까??");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. 아이템 구입\n2. 아이템 판매\n0. 마을로");
                Console.WriteLine("--------------------------------------");
                bool istrue = int.TryParse(Console.ReadLine(), out int myKey);

                if(istrue == false)
                {
                    continue;
                }
                else if (myKey == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("안녕히가세요");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
                else if(myKey == 1)
                {
                    Console.WriteLine("무엇을 구입하시겠습니까??");
                    ShowShopItem();
                    Console.WriteLine("구입할 아이템의 번호를 고르세요 (0번을 누르면 이전화면으로 돌아갑니다).");
                    bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                    if(isCorrect == false || inputNum > ShopItems.Count)
                    {
                        Console.WriteLine("아이템 번호를 입력하고 엔터를 누르세요");
                    }
                    else if(inputNum == 0)
                    {
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    else if(player.PlayerMoney < ShopItems[inputNum - 1].ItemPrice)
                    {
                        Console.WriteLine("지불할 돈이 모자릅니다");
                    }
                    else
                    {
                        player.BuyItem(ShopItems[inputNum - 1]);
                        player.PlayerMoney -= ShopItems[inputNum - 1].ItemPrice;
                        Console.WriteLine($"남은 돈 : {player.PlayerMoney}");
                    }
                }
                else if(myKey == 2)
                {
                    Console.WriteLine("무엇을 판매하시겠습니까??");
                    player.ShowPlayerSellInven();
                    Console.WriteLine("판매할 아이템의 번호를 고르세요 (0번을 누르면 이전화면으로 돌아갑니다).");
                    bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                    if (isCorrect == false || inputNum > ShopItems.Count)
                    {
                        Console.WriteLine("아이템 번호를 입력하고 엔터를 누르세요");
                    }
                    else if (inputNum == 0)
                    {
                        Thread.Sleep(1000);
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        player.SellItem(ShopItems[inputNum - 1]);
                        player.PlayerMoney += ShopItems[inputNum - 1].ItemPrice / 2;
                        Console.WriteLine($"남은 돈 : {player.PlayerMoney}");
                    }
                }
                else
                {
                    continue;
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
