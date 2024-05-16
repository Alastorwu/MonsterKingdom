using System.Collections.Generic;

namespace Model
{
    public class Monster
    {
        private string _cfgId;
        private List<Skill> _skills = new();
        
        public string CfgId
        {
            get => _cfgId;
            set
            {
                _cfgId = value;
            }
        }

        public List<Skill> Skills => _skills;
    }
}