
using System.Collections.Generic;

namespace Model
{
    public class Team
    {
        private Monster[] _monsters = new Monster[3];
        
        public Monster[] Monsters
        {
            get => _monsters;
            set => _monsters = value;
        }
    }
}


