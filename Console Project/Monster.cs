using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    enum MonsterSkill
    {

    }
    abstract class Monster
    {
        public string MonsterName { get; set; }
        public int MonsterHP{ get; set; }
        public int MonsterMP { get; set; }
        public int MonsterDamage { get; set; }
        public int MonsterDefensivePower { get; set; }
        public int MonsterCounter { get; set; }

        public MonsterSkill MonsterSkill { get; set; }
        public int MonsterGiveExp { get; set; }
        public int MonsterGiveMoney { get; set; }
    }
}
