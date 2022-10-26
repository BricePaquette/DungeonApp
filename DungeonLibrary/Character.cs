namespace DungeonLibrary
{
    public abstract class Character
    {
        private int _life;
        public int MaxLife { get; set; }
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {

                _life = value <= MaxLife ? _life = value : MaxLife;

                //if (value <= _maxLife)//prop or field
                //{
                //    _life = value;
                //}
                //else
                //{
                //    _life = MaxLife;
                //}
            }
        }
        public Character()
        {

        }
        public Character(int maxLife, string name, int hitChance, int block)
        {
            MaxLife = maxLife;
            Life = MaxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;

        }
        public override string ToString()
        {
            //return string.Format($"Name: {Name}\nCurrent Life: {Life}\nMaximum Life: {MaxLife}\nHit Chance: {HitChance}\nBlock: {Block}");
            return $"-----{Name}-----\nLife: {Life} of {MaxLife}\nHit Chance: {CalcHitChance()}%\nBlock: {Block}\n";
        }

        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcDamage()
        {
            return 0;
        }


    }
}