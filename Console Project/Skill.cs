using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    abstract class Skill
    {
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public int SkillDamage { get; set; }
        public int SkillMP { get; set; }

        public Skill(string skillName, string skillDescription, int skillDamage, int skillMP)
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            SkillDamage = skillDamage;
            SkillMP = skillMP;
        }
        public abstract void SkillAttack(Player player, Monster monster);

    }
}
