using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Player
    {
        public string Name { get; set; }
        public int PlayerLevel { get; set; }
        public int PlayerExp { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int Damage { get; set; }
        public int DefensivePower { get; set; }
        public int PlayerMoney { get; set; }

        public int PlayerPosX { get; set; }
        public int PlayerPosY { get; set; }
        public bool IsHome{ get; set; }
        public int MaxHp { get; set; }
        public int MaxMp { get; set; }
        List<Item> inven { get; set; }
        Item[] _weaponItem = new Item[1];
        Item[] _armorItem = new Item[1];
        public List<Skill> PlayerSkills { get;  set; }
        ConsoleKeyInfo myKey;

        public Player(int hp, int mp, int damage, int defensivePower)
        {
            Name = "한스";
            PlayerLevel = 4;
            PlayerExp = 99;
            MaxHp = 100;
            HP = hp;
            MaxMp = 100;
            MP = mp;
            Damage = damage;
            DefensivePower = defensivePower;
            PlayerMoney = 100;
            _weaponItem[0] = new Item("낡은 장검", 5, 0, ItemType.Weapon);
            _armorItem[0] = new Item("낡은 갑옷", 1, 0, ItemType.Armor);
        }

        public void SetPlayerPos()
        {
            PlayerPosX = 1;
            PlayerPosY = 2;
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
                if (inven[i].ItemType == ItemType.UsableHP)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t회복력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 물약");
                }
                if (inven[i].ItemType == ItemType.UsableMP)
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
                if (inven[i].ItemType == ItemType.UsableHP)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t회복력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice / 2}\t아이템 종류: 물약");
                }
                if (inven[i].ItemType == ItemType.UsableMP)
                {
                    Console.WriteLine($"[{i + 1}]. 이름: {inven[i].ItemName}\t회복력: {inven[i].ItemEffect}\t아이템 가격 : {inven[i].ItemPrice}\t아이템 종류: 물약");
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

        public void SellItem(int inputNum)
        {
            PlayerMoney += inven[inputNum - 1].ItemPrice;
            inven.Remove(inven[inputNum - 1]);
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
            Console.Clear();
            while (true)
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
            Console.Clear();
        }

        public void CreatePlayerSkillSlot()
        {
            PlayerSkills = new List<Skill>();
        }

        public void PlayerLveleUp()
        {
            if(PlayerExp == 100)
            {
                Console.WriteLine("레벨업!!");
                PlayerLevel++;
                PlayerExp = 0;
                HP = MaxHp;
                MP = MaxMp;
                Damage += 10;
                DefensivePower += 1;
                if (PlayerLevel == 5)
                {
                    Console.WriteLine("스킬 강타를 획득하였다!!");
                    PlayerSkills.Add(new SkillSmite("강타", "공격력 + 10만큼의 데미지를 준다", Damage + 10, 5));
                }
                else if (PlayerLevel == 15)
                {
                    Console.WriteLine("스킬 트리플 슬래쉬를 획득하였다!!");
                    PlayerSkills.Add(new SkillTrippleSlash("트리플 슬래쉬", "공격력 + 20만큼의 데미지를 준다", Damage + 20, 10));
                }
                else if (PlayerLevel == 25)
                {
                    Console.WriteLine("스킬 신성 강타를 획득하였다!!");
                    PlayerSkills.Add(new SkillHolySmite("신성 강타", "공격력 두배 만큼의 데미지를 준다", Damage * 2, 20));
                }
            }
            else if(PlayerExp > 100)
            {
                Console.WriteLine("레벨업!!");
                int rest = PlayerExp - 100;
                PlayerLevel++;
                PlayerExp = 0 + rest;
                HP = MaxHp;
                MP = MaxMp;
                Damage += 10;
                DefensivePower += 1;
                if (PlayerLevel == 5)
                {
                    Console.WriteLine("스킬 강타를 획득하였다!!");
                    PlayerSkills.Add(new SkillSmite("강타", "공격력 + 10만큼의 데미지를 준다", Damage + 10, 5));
                }
                else if (PlayerLevel == 15)
                {
                    Console.WriteLine("스킬 트리플 슬래쉬를 획득하였다!!");
                    PlayerSkills.Add(new SkillTrippleSlash("트리플 슬래쉬", "공격력 + 20만큼의 데미지를 준다", Damage + 20, 10));
                }
                else if (PlayerLevel == 25)
                {
                    Console.WriteLine("스킬 신성 강타를 획득하였다!!");
                    PlayerSkills.Add(new SkillHolySmite("신성 강타", "공격력 두배 만큼의 데미지를 준다", Damage * 2, 20));
                }
            }
        }

        public void UseUsableItem()
        {
            List<Item> usableitem = new List<Item>();
            for(int i = 0; i < inven.Count; i++)
            {
                if (inven[i].ItemType == ItemType.UsableHP || inven[i].ItemType == ItemType.UsableMP)
                {
                    usableitem.Add(inven[i]);
                }
            }
            if(usableitem.Count == 0)
            {
                Console.WriteLine("사용할 수 있는 아이템이 없습니다");
                
            }
            else if(usableitem.Count != 0)
            {
                Console.WriteLine("사용할 아이템을 선택하세요");
                for (int i = 0; i < usableitem.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}]. {usableitem[i].ItemName}\t회복량 : {usableitem[i].ItemEffect}\t가격 : {usableitem[i].ItemPrice}");
                }
                bool isCorrect = int.TryParse(Console.ReadLine(), out int inputNum);
                if (usableitem[inputNum - 1] != null)
                {
                    if (usableitem[inputNum - 1].ItemType == ItemType.UsableHP)
                    {
                        HP += usableitem[inputNum - 1].ItemEffect;
                        if(HP > 100)
                        {
                            HP = 100;
                        }
                        Console.WriteLine($"HP가 {usableitem[inputNum - 1].ItemEffect}만큼 회복되었습니다");
                    }
                    else if (usableitem[inputNum - 1].ItemType == ItemType.UsableMP)
                    {
                        MP += usableitem[inputNum - 1].ItemEffect;
                        if (MP > 100)
                        {
                            MP = 100;
                        }
                        Console.WriteLine($"MP가 {usableitem[inputNum - 1].ItemEffect}만큼 회복되었습니다");
                    }
                }
            }
            
            
        }
        public void MoveForward(Map map, BattleSystem battleSystem, MonsterManager monster, Player player)
        {
            if (map.TileTypes[PlayerPosX, PlayerPosY + 1] == Map.TileType.Wall)
            {
                PlayerPosX = PlayerPosX;
                PlayerPosY = PlayerPosY;
            }
            else if(map.TileTypes[PlayerPosX, PlayerPosY + 1] == Map.TileType.Empty)
            {
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Empty;
                PlayerPosY++;
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Player;
            }
            else if(map.TileTypes[PlayerPosX, PlayerPosY + 1] == Map.TileType.Monster)
            {
                battleSystem.NomalMonsterBattle(player, monster, map, PlayerPosX, PlayerPosY + 1);
            }
            else if (map.TileTypes[PlayerPosX, PlayerPosY + 1] == Map.TileType.BossMonster)
            {
                battleSystem.BossMonsterBattle(player, monster);
            }
            else if (map.TileTypes[PlayerPosX, PlayerPosY + 1] == Map.TileType.Menu)
            {
                IsHome = map.Menus();
            }
        }

        public void MoveBackward(Map map, BattleSystem battleSystem, MonsterManager monster, Player player)
        {
            if (map.TileTypes[PlayerPosX, PlayerPosY - 1] == Map.TileType.Wall)
            {
                PlayerPosX = PlayerPosX;
                PlayerPosY = PlayerPosY;
            }
            else if (map.TileTypes[PlayerPosX, PlayerPosY - 1] == Map.TileType.Empty)
            {
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Empty;
                PlayerPosY--;
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Player;
            }
            else if (map.TileTypes[PlayerPosX, PlayerPosY - 1] == Map.TileType.Monster)
            {
                battleSystem.NomalMonsterBattle(player, monster, map, PlayerPosX, PlayerPosY - 1);
            }
            else if (map.TileTypes[PlayerPosX, PlayerPosY - 1] == Map.TileType.BossMonster)
            {
                battleSystem.BossMonsterBattle(player, monster);
            }
            else if (map.TileTypes[PlayerPosX, PlayerPosY - 1] == Map.TileType.Menu)
            {
                IsHome = map.Menus();
            }
        }

        public void MoveRight(Map map, BattleSystem battleSystem, MonsterManager monster, Player player)
        {
            if (map.TileTypes[PlayerPosX + 1, PlayerPosY] == Map.TileType.Wall)
            {
                PlayerPosX = PlayerPosX;
                PlayerPosY = PlayerPosY;
            }
            else if (map.TileTypes[PlayerPosX + 1, PlayerPosY] == Map.TileType.Empty)
            {
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Empty;
                PlayerPosX++;
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Player;
            }
            else if (map.TileTypes[PlayerPosX + 1, PlayerPosY] == Map.TileType.Monster)
            {
                battleSystem.NomalMonsterBattle(player, monster, map, PlayerPosX + 1, PlayerPosY);
            }
            else if (map.TileTypes[PlayerPosX + 1, PlayerPosY] == Map.TileType.BossMonster)
            {
                battleSystem.BossMonsterBattle(player, monster);
            }
            else if (map.TileTypes[PlayerPosX + 1, PlayerPosY] == Map.TileType.Menu)
            {
                IsHome = map.Menus();
            }
        }

        public void MoveLeft(Map map, BattleSystem battleSystem, MonsterManager monster, Player player)
        {
            if (map.TileTypes[PlayerPosX - 1, PlayerPosY] == Map.TileType.Wall)
            {
                PlayerPosX = PlayerPosX;
                PlayerPosY = PlayerPosY;
            }
            else if (map.TileTypes[PlayerPosX - 1, PlayerPosY] == Map.TileType.Empty)
            {
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Empty;
                PlayerPosX--;
                map.TileTypes[PlayerPosX, PlayerPosY] = Map.TileType.Player;
            }
            else if (map.TileTypes[PlayerPosX - 1, PlayerPosY] == Map.TileType.Monster)
            {
                battleSystem.NomalMonsterBattle(player, monster, map, PlayerPosX - 1, PlayerPosY);
                
            }
            else if (map.TileTypes[PlayerPosX - 1, PlayerPosY] == Map.TileType.BossMonster)
            {
                battleSystem.BossMonsterBattle(player, monster);

            }
            else if (map.TileTypes[PlayerPosX - 1, PlayerPosY] == Map.TileType.Menu)
            {
                IsHome = map.Menus();
            }
        }

        

        public void PrintBattlePlayerInfo()
        {
            Console.WriteLine("플레이어 상태창");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"플레이어 HP : {HP}\t 플레이어 MP : {MP}");
            Console.WriteLine("--------------------------------------");
        }

        public void PrintPlayerSimpleInfo()
        {
            Console.WriteLine("플레이어의 상태");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"플레이어 이름 : {Name}\t 플레이어 레벨 : {PlayerLevel}\t플레이어 경험치 : {PlayerExp}");
            Console.WriteLine($"플레이어 HP : {HP}\t플레이어 MP : {MP}\t플레이어 돈 : {PlayerMoney}");
            Console.WriteLine($"플레이어 공격력 : {Damage}\t플레이어 방어력 : {DefensivePower}");
            Console.WriteLine("--------------------------------------");
        }

        public void PrintPlayerInfo()
        {
           
                Console.WriteLine("플레이어의 상태");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"플레이어 이름 : {Name}\t 플레이어 레벨 : {PlayerLevel}\t플레이어 경험치 : {PlayerExp}");
                Console.WriteLine($"플레이어 HP : {HP}\t플레이어 MP : {MP}\t플레이어 돈 : {PlayerMoney}");
                Console.WriteLine($"플레이어 공격력 : {Damage}\t플레이어 방어력 : {DefensivePower}");
                Console.WriteLine("--------------------------------------");
                ShowPlayerInven();
                PrintPlayerSkill();
                
        }
        public void PrintBattleMapPlayerInfo()
        {
            while(true)
            {
                Console.WriteLine("플레이어의 상태");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"플레이어 이름 : {Name}\t 플레이어 레벨 : {PlayerLevel}\t플레이어 경험치 : {PlayerExp}");
                Console.WriteLine($"플레이어 HP : {HP}\t플레이어 MP : {MP}\t플레이어 돈 : {PlayerMoney}");
                Console.WriteLine($"플레이어 공격력 : {Damage}\t플레이어 방어력 : {DefensivePower}");
                Console.WriteLine("--------------------------------------");
                ShowPlayerInven();
                PrintPlayerSkill();
                Console.WriteLine("0번을 누르면 맵으로 나감");

                myKey = Console.ReadKey(true);

                if (myKey.Key == ConsoleKey.D0 || myKey.Key == ConsoleKey.NumPad0)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public void PrintPlayerSkill()
        {
            Console.WriteLine("플레이어 스킬창");
            Console.WriteLine("--------------------------------------");
            for(int i = 0; i < PlayerSkills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {PlayerSkills[i].SkillName}  {PlayerSkills[i].SkillDescription}  데미지 : {PlayerSkills[i].SkillDamage}  소모MP : {PlayerSkills[i].SkillMP}");
            }
            Console.WriteLine("--------------------------------------");
        }
    }
}
