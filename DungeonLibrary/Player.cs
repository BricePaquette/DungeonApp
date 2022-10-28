using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {

        public MoralityType Morality { get; set; }
        public Weapon? EquipedWeapon { get; set; }
        public int CharmChance { get; set; }
        public Player()
        {

        }
        public Player(int maxLife, string name, int hitChance, int block, MoralityType morality, Weapon equipedWeapon, int charmChance) 
            : base(maxLife, name, hitChance, block)
        {
            Morality = morality;
            EquipedWeapon = equipedWeapon;
            CharmChance = charmChance;
            switch (Morality)
            {
                case MoralityType.Lawful_Good:
                    MaxLife += 10;
                    CharmChance += 15;
                    break;
                case MoralityType.Lawful_Neutral:
                    MaxLife += 10;
                    Block += 15;
                    break;
                case MoralityType.Lawful_Evil:
                    MaxLife += 10;
                    HitChance += 15;
                    break;
                case MoralityType.Chaotic_Good:
                    EquipedWeapon.BonusHitChance += 15;
                    CharmChance += 15;
                    break;
                case MoralityType.Chaotic_Neutral:
                    EquipedWeapon.MinDamge = EquipedWeapon.MaxDamge - 3;
                    Block += 15;
                    break;
                case MoralityType.Chaotic_Evil:
                    EquipedWeapon.MaxDamge += 4;
                    HitChance += 15;
                    break;
                case MoralityType.Neutral:
                    break;
                default:
                    Console.WriteLine("Imposible I say... IMPOSIBLE");
                    break;
            }
        }

        public override string ToString()
        {
            return $"\nMorality: {Morality.ToString().Replace('_', ' ')}\t" + base.ToString() + $"\nWeapon {EquipedWeapon}\n";

        }

        public override int CalcDamage()
        {
            Random rand = new Random();
            int randomDamage = rand.Next(EquipedWeapon.MinDamge, EquipedWeapon.MaxDamge + 1);

            return randomDamage;

        }
        public override int CalcHitChance()
        {
            return HitChance + EquipedWeapon.BonusHitChance;
        }

    }
}
