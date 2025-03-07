using System;

namespace UI
{
    public class SkillChooseData : UIData
    {
        public int monsterIndex;
        public int skillIndex;
        public Action<string> onMonsterChoose;
    }
}