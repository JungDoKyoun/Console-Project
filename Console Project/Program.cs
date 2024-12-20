using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player myPlayer = new Player(10, 10, 10, 10, PlayerSkill.non, 10000);
            myPlayer.CreateInven();
            myPlayer.AddItem();
            myPlayer.ShowPlayerInven();
        }
    }
}
