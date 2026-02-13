using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgrammingII_Project01_FirstPlayable_LucasHardy
{
    public abstract class Character
    {
        public Health Health { get; protected set; }
        public int Damage { get; set; }

        public int XPos { get;set; }
        public int YPos { get; set; }

        public char Icon { get; protected set; }

        public virtual void TakeDamage(int damageAmount)
        {
            Health.TakeDamage(damageAmount);
        }
        public void Move(int x, int y)
        {
            XPos += x;
            YPos += y;
        }
        public abstract void Attack(Character target);
        public abstract void Draw();
        public abstract void Movement();
        protected Character(char icon, int x, int y)
        {
            Icon = icon;
            XPos = x;
            YPos = y;
        }
    }
}
