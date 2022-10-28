using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon
    {
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private WeaponType _type;


        //Properties
        public int MaxDamge
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }

        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }
        public WeaponType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string Description { get; set; }
        public int MinDamge
        {
            get { return _minDamage; }
            set
            {
                _minDamage = (value > 0 && value <= MaxDamge) ? value : 1;

            }

        }
        //Constructors
        public Weapon()
        {

        }
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, WeaponType type, string description)
        {
            _maxDamage = maxDamage;
            _minDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            Type = type;
            Description = description;
        }

        //Methods()
        public override string ToString()
        {
            return string.Format($"Name: {Name}\t{MinDamge} to {MaxDamge} Damage\nBonus Hit Chance: {BonusHitChance}%\nWeapon type: {Type}\nDescription: {Description}");
        }



    }
}
