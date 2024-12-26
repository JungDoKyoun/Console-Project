using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class GameManager
    {
        Player player = new Player(10, 10, 10, 10);
        
        
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
        battle.NomalMonsterBattle(myPlayer, monster);
    }
}
