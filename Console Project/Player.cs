using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    enum PlayerSkill
    {
        non, Blow, 
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

        public Player(int hp, int mp, int damage, int defensivePower, PlayerSkill playerSkill, int playerMoney)
        {
            HP = hp;
            MP = mp;
            Damage = damage;
            DefensivePower = defensivePower;
            PlayerSkill = playerSkill;
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
            foreach(Item item in inven)
            {
                if(item.ItemType == ItemType.Weapon )
                {
                    Console.WriteLine($"이름: {item.ItemName}\t공격력: {item.ItemEffect}\t아이템 종류: 무기");
                }
                if (item.ItemType == ItemType.Armor)
                {
                    Console.WriteLine($"이름: {item.ItemName}\t방어력: {item.ItemEffect}\t아이템 종류: 방어구");
                }
                if (item.ItemType == ItemType.Usable)
                {
                    Console.WriteLine($"이름: {item.ItemName}\t회복력: {item.ItemEffect}\t아이템 종류: 물약");
                }
            }
            Console.WriteLine();
            Console.WriteLine(PlayerMoney);
            Console.WriteLine("----------------------------------------------");
        }

        public void AddItem()
        {
            inven.Add(new Item("검", 10, ItemType.Weapon));
            inven.Add(new Item("갑옷", 10, ItemType.Armor));
            inven.Add(new Item("빨간물약", 10, ItemType.Usable));
        }
    }
}
