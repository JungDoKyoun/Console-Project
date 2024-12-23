using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public int HP { get; set; }
        public int MP { get; set; }
        public int Damage { get; set; }
        public int DefensivePower { get; set; }
        public PlayerSkill PlayerSkill { get; set; }
        public int PlayerMoney { get; set; }

        public int PlayerPosX { get; set; }
        public int PlayerPosY { get; set; }
        List<Item> inven;

        public Player(int hp, int mp, int damage, int defensivePower, int playerMoney)
        {
            HP = hp;
            MP = mp;
            Damage = damage;
            DefensivePower = defensivePower;
            PlayerMoney = playerMoney;
            PlayerPosX = 0;
            PlayerPosY = 0;

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
                    Console.WriteLine($"[{i}]. 이름: {inven[i].ItemName}\t공격력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 무기");
                }
                if (inven[i].ItemType == ItemType.Armor)
                {
                    Console.WriteLine($"[{i}]. 이름: {inven[i].ItemName}\t방어력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 방어구");
                }
                if (inven[i].ItemType == ItemType.Usable)
                {
                    Console.WriteLine($"[{i}]. 이름: {inven[i].ItemName}\t회복력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 물약");
                }
            }
            Console.WriteLine();
            Console.WriteLine(PlayerMoney);
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
            Console.WriteLine(PlayerMoney);
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
    }
}
