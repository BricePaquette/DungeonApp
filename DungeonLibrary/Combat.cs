using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {

        #region Potential Expansion - Initiative

        //Consider adding an "Initiative" property to Character
        //Then check the Initiative to determine who attacks first
        //if (player.Initiative >= monster.Initiative)
        //{
        //    DoAttack(player, monster);
        //}
        //else
        //{
        //    DoAttack(monster, player);
        //}

        #endregion
        #region Possible Expansion - Levels of Play - Block 5

        //Possible Expansion: 
        //Define levels of play
        //int[] levels = { 5, 12, 20, 30, 45 };//Use with experience property in Character
        //inherited down to Player and Monster, to scale levelling.

        #endregion

        //One-sided attack
        public static void DoAttack(Character attacker, Character defender)
        {
            //roll a 100 sided die
            int roll = new Random().Next(1, 101);
            Thread.Sleep(50);
            //The attacker hits if the roll is less than the attackers hit - the defenders block
            if (roll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //calculate the damage
                int damageDealt = attacker.CalcDamage();
                //detract that damage from the defenders life
                defender.Life -= damageDealt;
                //output the results to the screen
                //red text helps indicate damage
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();//turns the color back to normal
            }
            else
            {
                Console.WriteLine($"{attacker.Name} missed sheesh");
            }
        }

        //create a method to handle battle an attack from both sides
        public static void DoBattle(Player player, Pirate monster)
        {
            DoAttack(player, monster);
            //if the monster survives let them attack the player
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }
        }
    }
}