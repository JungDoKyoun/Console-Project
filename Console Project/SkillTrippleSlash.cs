using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class SkillTrippleSlash : Skill
    {
        public SkillTrippleSlash(string skillName, string skillDescription, int skillDamage, int skillMP) : base(skillName, skillDescription, skillDamage, skillMP)
        {
        }

        public override void SkillAttack(Player player, Monster monster)
        {
            monster.MonsterHP -= SkillDamage - monster.MonsterDefensivePower;
            player.MP -= SkillMP;
            Console.WriteLine($"{SkillName}로 공격하여 {SkillDamage - monster.MonsterDefensivePower}만큼의 피해를 입혀 {monster.MonsterHP}만큼 HP가 남았습니다");
        }
    }
}
