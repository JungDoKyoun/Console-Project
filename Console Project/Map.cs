using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Map
    {
        public TileType[,] TileTypes { get; set; }
        public int Size1 { get; set; }
        public int Size2 { get; set; }
        const char RECTANGLE = '■';
        const char Player = '★';
        const char Monster = '◈';
        const char BossMonster = '♣';
        const char Menu = '♠';

        public enum TileType
        {
            Empty, Wall, Player, Monster, BossMonster, Menu
        }

        ConsoleColor MapColor(TileType type)
        {
            switch(type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Gray;
                case TileType.Player:
                    return ConsoleColor.Blue;
                case TileType.Monster:
                    return ConsoleColor.Red;
                case TileType.BossMonster:
                    return ConsoleColor.Yellow;
                case TileType.Menu:
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.Green;
            }
        }

        public void Initialize(int size1, int size2)
        {
            TileTypes = new TileType[size2, size1];
            Size1 = size1;
            Size2 = size2;

            for(int y = 0; y < Size2; y++)
            {
                for(int x = 0; x < Size1; x++)
                {
                    if(x == 0 || x == Size1 - 1 || y == 0 || y == Size2 - 1)
                    {
                        TileTypes[y, x] = TileType.Wall;
                    }
                    else if(y == 10)
                    {
                        TileTypes[y, x] = TileType.Wall;
                    }
                    else
                    {
                        TileTypes[y, x] = TileType.Empty;
                    }
                }
            }
            TileTypes[1, 2] = TileType.Player;
            TileTypes[10, 5] = TileType.Empty;
            TileTypes[1, 1] = TileType.Menu;

        }
        public bool Menus()
        {
            return true;
        }

        public void Render(Player player, MonsterManager monster)
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for(int y = 0; y < Size2; y++)
            {
                for(int x = 0; x < Size1; x++)
                {
                    if(TileType.Empty == TileTypes[y , x])
                    {
                        Console.ForegroundColor = MapColor(TileType.Empty);
                        Console.Write(RECTANGLE);
                    }
                    else if(TileType.Wall == TileTypes[y, x])
                    {
                        Console.ForegroundColor = MapColor(TileType.Wall);
                        Console.Write(RECTANGLE);
                    }
                    else if (TileTypes[y, x] == TileType.Player)
                    {
                        Console.ForegroundColor = MapColor(TileType.Player);
                        Console.Write(Player);
                    }
                    else if(TileTypes[y, x] == TileType.Menu)
                    {
                        Console.ForegroundColor = MapColor(TileType.Menu);
                        Console.Write(Menu);
                    }
                    else if (TileTypes[y, x] == TileType.Monster)
                    {
                        Console.ForegroundColor = MapColor(TileType.Monster);
                        Console.Write(Monster);
                    }
                    else if (TileTypes[y, x] == TileType.BossMonster)
                    {
                        Console.ForegroundColor = MapColor(TileType.BossMonster);
                        Console.Write(BossMonster);
                    }
                }

                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
