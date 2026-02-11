using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    public class Health
    {
        public int CurrentHealth { get; private set; }
        public int Max { get; private set; }
        public bool _isAlive = true;

        public Health(int maxHealth)
        {
            Max = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            CurrentHealth -= damageAmount;
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                _isAlive = false;
            }
        }

        public void Heal(int healAmount)
        {
            if (!_isAlive) return;

            CurrentHealth += healAmount;
            if (CurrentHealth > Max)
            {
                CurrentHealth = Max;
            }
        }
        public bool IsDead()
        {
            // if health is below or zero ill tell the program that the character is dead.
            return CurrentHealth <= 0;
        }
    }
}
