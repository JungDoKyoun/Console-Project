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
        public int MonsterLevel { get; set; }
        public int MonsterHP{ get; set; }
        public int MonsterMP { get; set; }
        public int MonsterDamage { get; set; }
        public int MonsterDefensivePower { get; set; }
        public static int MonsterCounter { get; set; }

        public MonsterSkill MonsterSkill { get; set; }
        public int MonsterGiveExp { get; set; }
        public int MonsterGiveMoney { get; set; }
        public int MonsterPosX { get; set; }
        public int MonsterPosY { get; set; }

        public Monster(string name, int level, int HP, int MP, int damage, int Def,int exp, int money)
        {
            MonsterName = name;
            MonsterLevel = level;
            MonsterHP = HP;
            MonsterMP = MP;
            MonsterDamage = damage;
            MonsterDefensivePower = Def;
            MonsterGiveExp = exp;
            MonsterGiveMoney = money;
        }
        public Monster()
        {
            
        }

        public abstract void SetMonster(Map map);
    }
}
