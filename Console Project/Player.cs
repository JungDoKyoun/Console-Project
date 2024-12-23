using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    enum PlayerSkill
    {
        Blow, 
    }
    internal class Player
    {
        public string Name { get; set; }
        public int PlayerLevel { get; set; }
        public int PlayerExp { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Damage { get; set; }
        public int DefensivePower { get; set; }
        public PlayerSkill PlayerSkill { get; set; }
        public int PlayerMoney { get; set; }

        public int PlayerPosX { get; set; }
        public int PlayerPosY { get; set; }
        List<Item> inven;
        Item[] _weaponItem = new Item[1];
        Item[] _armorItem = new Item[1];
        ConsoleKeyInfo myKey;

        public Player(int hp, int mp, int damage, int defensivePower)
        {
            PlayerLevel = 1;
            PlayerExp = 0;
            HP = hp;
            MP = mp;
            Damage = damage;
            DefensivePower = defensivePower;
            PlayerMoney = 100;
            _weaponItem[0] = new Item("낡은 장검", 10, 0, ItemType.Weapon);
            _armorItem[0] = new Item("낡은 갑옷", 5, 0, ItemType.Armor);
        }

        public void SetPlayerPos()
        {
            PlayerPosX = 1;
            PlayerPosY = 1;
        }
        public void CreateInven()
        {
            inven = new List<Item>();
        }

        public void ShowPlayerInven()
        {
            Console.WriteLine("현재 인벤토리 항목");
            Console.WriteLine("----------------------------------------------");


            if(inven.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다");
            }
            for(int i = 0; i < inven.Count; i++)
            {
                if (inven[i].ItemType == ItemType.Weapon )
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t공격력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 무기");
                }
                if (inven[i].ItemType == ItemType.Armor)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t방어력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 방어구");
                }
                if (inven[i].ItemType == ItemType.Usable)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t회복력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 물약");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"남은 돈 : {PlayerMoney}");
            Console.WriteLine("----------------------------------------------");
        }

        public void ShowPlayerSellInven()
        {
            Console.WriteLine("현재 인벤토리 항목");
            Console.WriteLine("----------------------------------------------");


            if (inven.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다");
            }
            for (int i = 0; i < inven.Count; i++)
            {
                if (inven[i].ItemType == ItemType.Weapon)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t공격력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice / 2}\t아이템 종류: 무기");
                }
                if (inven[i].ItemType == ItemType.Armor)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t방어력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice / 2}\t아이템 종류: 방어구");
                }
                if (inven[i].ItemType == ItemType.Usable)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t회복력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice / 2}\t아이템 종류: 물약");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"남은 돈 : {PlayerMoney}");
            Console.WriteLine("----------------------------------------------");
        }

        public void ShowEquipmentSet()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"1. 무기 : {_weaponItem[0]?.ItemName}\t2.방어구 : {_armorItem[0]?.ItemName}");
            Console.WriteLine("----------------------------------------------");
        }

        public void BuyItem(Item item)
        {
            inven.Add(item);
        }

        public void SellItem(Item item)
        {
            inven.Remove(item);
        }

        public void Equipment(Item item)
        {
            if(item.ItemType == ItemType.Weapon)
                {
                if(_weaponItem[0] != null)
                {
                    Console.WriteLine($"{_weaponItem[0].ItemName}을 착용중입니다");
                }
                else
                {
                    _weaponItem[0] = item;
                    inven.Remove(item);
                    Console.WriteLine($"{item.ItemName}을 착용하였습니다");
                }
            }

            if (item.ItemType == ItemType.Armor)
            {
                if (_armorItem[0] != null)
                {
                    Console.WriteLine($"{_weaponItem[0].ItemName}을 착용중입니다");
                }
                else
                {
                    _armorItem[0] = item;
                    inven.Remove(item);
                    Console.WriteLine($"{item.ItemName}을 착용하였습니다");
                }
            }
        }

        public void DisEquipment(Item item)
        {
            if (item.ItemType == ItemType.Weapon)
            {
                if (_weaponItem[0] == null)
                {
                    Console.WriteLine("무기를 착용하지 않은 상태입니다");
                }
                else
                {
                    _weaponItem[0] = null;
                    inven.Add(item);
                    Console.WriteLine($"{item.ItemName}을 해체하였습니다");
                }
            }

            if (item.ItemType == ItemType.Armor)
            {
                if (_armorItem[0] == null)
                {
                    Console.WriteLine("방어구를 착용하지 않은 상태입니다");
                }
                else
                {
                    _armorItem[0] = null;
                    inven.Add(item);
                    Console.WriteLine($"{item.ItemName}을 해체하였습니다");
                }
            }
        }

        public void ThrowItem(int inputNum)
        {
            Console.WriteLine($"{inven[inputNum - 1].ItemName}을 버렸습니다");
            inven.Remove(inven[inputNum - 1]);
        }

        public void EquipmentSet()
        {
            while(true)
            {
                Console.WriteLine("할 행동을 선택하여 주세요");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. 아이템 장착\n2. 아이템 해체\n3. 아이템 버리기\n0. 메인 메뉴");
                Console.WriteLine("--------------------------------------");
                myKey = Console.ReadKey(true);

                if(myKey.Key == ConsoleKey.D0 || myKey.Key == ConsoleKey.NumPad0)
                {
                    break;
                }
                else if(myKey.Key == ConsoleKey.D1||myKey.Key == ConsoleKey.NumPad1)
                {
                    if (inven.Count == 0)
                    {
                        Console.WriteLine("아이템창이 비어있습니다");
                    }
                    else
                    {
                        Console.WriteLine("장비할 아이템을 선택해주세요(0번을 누르면 이전창으로 돌아갑니다)");
                        ShowPlayerInven();
                        bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                        {
                            if (isCorrect == false || inputNum > inven.Count)
                            {
                                Console.WriteLine("아이템중 하나를 선택하여 주세요");
                            }
                            else if(inputNum == 0)
                            {
                                continue;
                            }
                            else
                            {
                                Equipment(inven[inputNum - 1]);
                            }
                        }
                    }
                }
                else if (myKey.Key == ConsoleKey.D2 || myKey.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("해체할 아이템을 선택해주세요(0번을 누르면 이전창으로 돌아갑니다)");
                    ShowEquipmentSet();
                    bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                    if (isCorrect == false || inputNum > 2)
                    {
                        Console.WriteLine("아이템중 하나를 선택하여 주세요");
                    }
                    else if(inputNum == 1)
                    {
                        if (_weaponItem[0] == null)
                        {
                            Console.WriteLine("무기를 착용하지 않았습니다");
                        }
                        else
                        {
                            DisEquipment(_weaponItem[0]);
                        }
                    }
                    else if(inputNum == 2)
                    {
                        if (_armorItem[0] == null)
                        {
                            Console.WriteLine("방어구를 착용하지 않았습니다");
                        }
                        else
                        {
                            DisEquipment(_armorItem[0]);
                        }
                    }
                }
                else if (myKey.Key == ConsoleKey.D3 || myKey.Key == ConsoleKey.NumPad3)
                {
                    if (inven.Count == 0)
                    {
                        Console.WriteLine("아이템창이 비어있습니다");
                    }
                    else
                    {
                        Console.WriteLine("버릴 아이템을 선택해주세요(0번을 누르면 이전창으로 돌아갑니다)");
                        ShowPlayerInven();
                        bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                        {
                            if (isCorrect == false || inputNum > inven.Count)
                            {
                                Console.WriteLine("아이템중 하나를 선택하여 주세요");
                            }
                            else if (inputNum == 0)
                            {
                                continue;
                            }
                            else
                            {
                                ThrowItem(inputNum);
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void PlayerLveleUp()
        {
            Console.WriteLine("레벨업!!");
            if(PlayerExp == 100)
            {
                PlayerLevel++;
                PlayerExp = 0;
            }
            else if(PlayerExp > 100)
            {
                int rest = PlayerExp - 100;
                PlayerLevel++;
                PlayerExp = 0 + rest;
            }
            HP = 100;
            MP = 100;
            Damage += 10;
            DefensivePower += 5;
        }

        

    }
}
