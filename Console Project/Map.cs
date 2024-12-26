﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Map
    {
        public TileType[,] TileTypes { get; set; }
        public int Size { get; set; }
        const char RECTANGLE = '■';
        const char Player = '★';
        const char Monster = '◈';
        const char BossMonster = '♣';

        public enum TileType
        {
            Empty, Wall, Player, Monster, BossMonster
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
                default:
                    return ConsoleColor.Green;
            }
        }

        public void Initialize(int size)
        {
            TileTypes = new TileType[size, size];
            Size = size;

            for(int y = 0; y < Size; y++)
            {
                for(int x = 0; x < Size; x++)
                {
                    if(x == 0 || x == Size - 1 || y == 0 || y == Size - 1)
                    {
                        TileTypes[y, x] = TileType.Wall;
                    }
                    else
                    {
                        TileTypes[y, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render(Player player, MonsterManager monster)
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for(int y = 0; y < Size; y++)
            {
                for(int x = 0; x < Size; x++)
                {
                    if (y == player.PlayerPosY && x == player.PlayerPosX)
                    {
                        Console.ForegroundColor = MapColor(TileType.Player);
                        Console.Write(Player);
                    }
                    else if(y == monster.ReturnMonster().MonsterPosY && x == monster.ReturnMonster().MonsterPosX)
                    {
                        Console.ForegroundColor = MapColor(TileType.Monster);
                        Console.Write(Monster);
                    }
                    else if(y == monster.ReturnBossMonster().MonsterPosY && x == monster.ReturnBossMonster().MonsterPosX)
                    {
                        Console.ForegroundColor = MapColor(TileType.BossMonster);
                        Console.Write(BossMonster);
                    }
                    else
                    {
                        if(TileType.Empty == TileTypes[x, y])
                        {
                            Console.ForegroundColor = MapColor(TileType.Empty);
                            Console.Write(RECTANGLE);
                        }
                        else if(TileType.Wall == TileTypes[x, y])
                        {
                            Console.ForegroundColor = MapColor(TileType.Wall);
                            Console.Write(RECTANGLE);
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
