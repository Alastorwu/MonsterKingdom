using System.Collections.Generic;

namespace Model
{
    public class Monster
    {
        private string _cfgId;
        private Skill[] _skills = new Skill[4];
        
        public string CfgId
        {
            get => _cfgId;
            set
            {
                _cfgId = value;
            }
        }

        public Skill[] Skills
        {
            get => _skills;
            set => _skills = value;
        }

        public Monster()
        {
            for (int i = 0; i < 4; i++)
            {
                _skills[i] = new Skill();
            }
        }
    }
}