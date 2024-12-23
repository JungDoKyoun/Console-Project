using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Map
    {
        public TileType[,] _tile;
        public int _size;
        const char RECTANGLE = '■';
        const char Player = 'P';
        const char Monster = 'M';

        public enum TileType
        {
            Empty, Wall, Player, Monster
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
                default:
                    return ConsoleColor.Green;
            }
        }

        public void Initialize(int size)
        {
            _tile = new TileType[size, size];
            _size = size;

            for(int y = 0; y < _size; y++)
            {
                for(int x = 0; x < _size; x++)
                {
                    if(x == 0 || x == _size - 1 || y == 0 || y == _size - 1)
                    {
                        _tile[x, y] = TileType.Wall;
                    }
                    else
                    {
                        _tile[x, y] = TileType.Empty;
                    }
                }
            }
        }

    }
}
