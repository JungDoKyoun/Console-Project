using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class NomalMonster : Monster
    {
        public NomalMonster()
        {

        }
        public NomalMonster(string name, int level, int HP, int MP, int damage, int Def, int exp, int money, int posX, int posY) : base(name, level, HP, MP, damage, Def, exp, money, posX, posY)
        {
        }

    }   
}
