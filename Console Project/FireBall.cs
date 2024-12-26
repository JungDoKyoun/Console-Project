using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Project
{
    internal class FireBall : Skill
    {
        public FireBall(string skillName, string skillDescription, int skillDamage, int skillMP) : base(skillName, skillDescription, skillDamage, skillMP)
        {
        }

        public override void SkillAttack(Player player, Monster monster)
        {
            player.HP -= SkillDamage - player.DefensivePower;
            monster.MonsterMP -= SkillMP;
            Console.WriteLine($"{SkillName}로 공격하여 {SkillDamage - player.DefensivePower}만큼의 피해를 입혀 {player.HP}만큼 HP가 남았습니다");
        }
    }
}
