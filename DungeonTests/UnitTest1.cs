using DungeonLibrary;
using System.Numerics;

namespace DungeonTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Damage()
        {
            Weapon w = new Weapon(10, 10, "Sword of testing", 10, WeaponType.Cutlass, "Unblanced and untrue");
            Player p = new Player(10, "Tester guy", 10, 10, MoralityType.Neutral, w, 10);
            int expected = 10;
            int actual = p.CalcDamage();
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void Test_Block()
        {
            Weapon w = new Weapon(10, 10, "Sword of testing", 10, WeaponType.Cutlass, "Unblanced and untrue");
            Player p = new Player(10, "Tester guy", 10, 10, MoralityType.Neutral, w, 10);
            int expected = 10;
            int actual = p.CalcBlock();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test_HitChance()
        {
            Weapon w = new Weapon(10, 10, "Sword of testing", 10, WeaponType.Cutlass, "Unblanced and untrue");
            Player p = new Player(10, "Tester guy", 10, 10, MoralityType.Neutral, w, 10);
            int expected = 20;
            int actual = p.CalcHitChance();
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void Test_Drunk()
        {
            Captain tester = new Captain(10, 10, "Best Test", 10, 10, 10, 10, "A guy that is cool i guess", true);

            int expected = 17;
            int expected1 = 20;
            Assert.Equal(expected, tester.MaxDamage);
            Assert.Equal(expected1, tester.HitChance);
            
        }
        [Fact]
        public void Test_DoBattle()
        {
            Captain tester = new Captain(10, 10, "Best Test", 10, 10, 10, 10, "A guy that is cool i guess", true);
            Weapon w = new Weapon(10, 10, "Sword of testing", 10, WeaponType.Cutlass, "Unblanced and untrue");
            Player p = new Player(10, "Tester guy", 10, 10, MoralityType.Neutral, w, 10);

            Combat.DoBattle(p, tester);
            Assert.Equal(p.Life > tester.Life, tester.Life < p.Life);
        }
        [Fact]
        public void Test_DoAttack()
        {
            Captain tester = new Captain(10, 10, "Best Test", 10, 10, 10, 10, "A guy that is cool i guess", true);
            Weapon w = new Weapon(10, 10, "Sword of testing", 10, WeaponType.Cutlass, "Unblanced and untrue");
            Player p = new Player(10, "Tester guy", 10, 10, MoralityType.Neutral, w, 10);

            Combat.DoAttack(p, tester);
            Assert.Equal(p.Life > tester.Life, tester.Life < p.Life);
        }
    }
}