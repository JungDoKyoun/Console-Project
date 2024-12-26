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
        private string name;
        private int level;
        private int hP;
        private int mP;
        private int damage;
        private int def;
        private int exp;
        private int money;

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
        public object Value { get; }

        public Monster(string name, int level, int HP, int MP, int damage, int Def,int exp, int money, int posX, int posY)
        {
            MonsterName = name;
            MonsterLevel = level;
            MonsterHP = HP;
            MonsterMP = MP;
            MonsterDamage = damage;
            MonsterDefensivePower = Def;
            MonsterGiveExp = exp;
            MonsterGiveMoney = money;
            MonsterPosX = posX;
            MonsterPosY = posY;
        }
        public Monster()
        {
            
        }

        protected Monster(string name, int level, int hP, int mP, int damage, int def, int exp, int money)
        {
            this.name = name;
            this.level = level;
            this.hP = hP;
            this.mP = mP;
            this.damage = damage;
            this.def = def;
            this.exp = exp;
            this.money = money;
        }

        public Monster(string name, int level, int hP, int mP, int damage, int def, int exp, int money, object value) : this(name, level, hP, mP, damage, def, exp, money)
        {
            Value = value;
        }
    }
}
