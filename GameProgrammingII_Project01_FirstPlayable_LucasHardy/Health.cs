using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    internal class Health
    {
        static int _health;
        static int _maxHealth;
        public bool _isAlive = true;

        public Health(int health, int maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        }

    }
}
