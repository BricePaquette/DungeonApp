using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Captain : Pirate
    {
        public bool Drunk { get; set; }
        public Captain(int maxLife, int life, string name, int hitChance, int block, int maxDamage, int minDamage, string description, bool drunk) 
            : base(maxLife, life, name, hitChance, block, maxDamage, minDamage, description)
        {
            if (Drunk)
            {
                HitChance += 10;
                MaxDamage += 7;
            }
        }

        public bool DrunkGenerator()
        {
            Random random = new Random();
            int drunkTell = random.Next(1, 2);
            if (drunkTell == 2)
            {
                return Drunk = true;
            }
            else
            {
                return Drunk = false;
            }

        }

        
    }
}
