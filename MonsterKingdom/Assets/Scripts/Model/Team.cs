
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

        public Team()
        {
            for (int i = 0; i < 3; i++)
            {
                _monsters[i] = new Monster();
            }
        }
    }
}


