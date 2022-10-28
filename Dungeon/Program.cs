using DungeonLibrary;
using System.Diagnostics;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Boats
            List<string> boatDescriptions = new List<string>()
            {
                "You walk out onto the deck of the ship... Your surrounded by a fleet of what seems to be pirate ships and you hear men shouting about an intruder then",
                "The pirates’ ship is well-stocked with provisions. The ship's banner features a bloody dagger. The ship's mascot is a macaque",
                "The pirates’ ship is in need of repair. The ship's banner features an octopus. The ship's mascot is a budgie",
                "The pirates’ ship is “on loan” to some other pirates. The ship's banner features a sea turtle. The ship's mascot is a conure",
                "The pirates’ ship is barely staying afloat. The ship's banner features a bloody dagger",
                "The pirates’ ship is barely staying afloat. The ship's banner features a swordfish.",
                "This pirates ship looks as though it used to be a navy vessel, make sure youre in good shape to fight",
                "ship 6",
                "ship 7",
                "ship 8",
                
            };
            #endregion

            #region Weapons
            Weapon cutlass = new Weapon(10, 15, "Black Beards Cutlass", 30, WeaponType.Cutlass, "The legendary pirate Black Beard personal cutlass");
            Weapon blunderbuss = new Weapon(11, 14, "Big o'le Blunderbuss", 30, WeaponType.Musket, "Above average in size, this is a real gun");
            Weapon hook = new Weapon(9, 18, "Captain Hooks hook", 35, WeaponType.Hook, "I don't know why this speaks to you, but it does...");
            Weapon pike = new Weapon(12, 18, "The Pike", 20, WeaponType.Pike, "A long wooden pole with a metal pointy tip");
            Weapon shield = new Weapon(11, 11, "Cool Repelant", 35, WeaponType.Shield, "Cool Repelant is a circle wooden shield");

            List<Weapon> weapons = new List<Weapon>() 
            {
                cutlass, blunderbuss, hook, pike, shield
            };
            #endregion


            #region Player Creation
            
            Console.WriteLine("You wake on an anchored ship you hear voices, but before you act you start to remember who you are...\n\tPress any key to continue...");
            Console.ReadKey();
            Console.Clear();

            Console.Write("You start to mutter the letters that together make your name: ");
            string username = Console.ReadLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            
            

           
            //weapon and morality type
            bool isPlayerSureMorals = false;
            bool isPlayerSureWeapons = false;
            bool exit = false;
            Player player = new Player(40, username, 40, 40, MoralityType.Neutral, cutlass, 30);
            int loopCount = 0;
            while (!isPlayerSureMorals)
            {

                
                loopCount++;
                Console.WriteLine(loopCount);
                if (loopCount == 1)
                {
                    Console.WriteLine($"Okay Mr. {username} how are your morals");
                }
                else if (loopCount == 2)
                {
                    Console.WriteLine($"Back for a rety? Never the less what are your morals?");

                }
                else if (loopCount == 3)
                {
                    Console.WriteLine("You know what they say 3rd time is the charm");
                }
                else if (loopCount == 4)
                {
                    Console.WriteLine("At this point just check them all");
                }
                var moralityTypes = Enum.GetValues<MoralityType>().ToList();
                foreach (MoralityType m in moralityTypes)
                {
                    string display = m.ToString().Replace('_', ' ');
                    Console.WriteLine($"{(int)m + 1}) {display}");
                }
                int moral = int.Parse(Console.ReadLine()) - 1;
                MoralityType userMoral = (MoralityType)moral;


                switch (userMoral)
                {
                    case MoralityType.Lawful_Good:
                        Console.WriteLine("Overall boost to max hp and charm chance");
                        player.Morality = MoralityType.Lawful_Good;
                        break;
                    case MoralityType.Lawful_Neutral:
                        Console.WriteLine("Overall boost to max hp and block");
                        player.Morality = MoralityType.Lawful_Neutral;
                        break;
                    case MoralityType.Lawful_Evil:
                        Console.WriteLine("Overall boost to max hp and hit chance");
                        player.Morality = MoralityType.Lawful_Evil;
                        break;
                    case MoralityType.Chaotic_Good:
                        Console.WriteLine("Overall boost to damage and charm chance");
                        player.Morality = MoralityType.Chaotic_Good;
                        break;
                    case MoralityType.Chaotic_Neutral:
                        Console.WriteLine("Overall boost to damage and block");
                        player.Morality = MoralityType.Chaotic_Neutral;
                        break;
                    case MoralityType.Chaotic_Evil:
                        Console.WriteLine("Overall boost to damage and hit chance");
                        player.Morality = MoralityType.Chaotic_Evil;
                        break;
                    case MoralityType.Neutral:
                        break;
                    default:
                        Console.WriteLine("I didn't know stupid was an option");
                        break;
                }
                
                Console.WriteLine("Are you sure?\n" +
                    "Y) Yes\n" +
                    "N) No\n" +
                    "E) Exit\n");
                ConsoleKey playerMoralityConfirmation = Console.ReadKey(true).Key;
                switch (playerMoralityConfirmation)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("Ahh now that you've said it it makes sense\nPress any key to continue...");
                        Console.ReadKey();
                        isPlayerSureMorals = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.N:
                        Console.Clear();
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("Makes sense later man");
                        exit = true;
                        isPlayerSureMorals = true;
                        isPlayerSureWeapons = true;
                        break;
                    default:
                        Console.WriteLine("You should probably quit man this is a text game and you obviously cant read");
                        break;
                }
            }
            while (!isPlayerSureWeapons)
            {
                Console.WriteLine($"Now we have a fine assortment of weapons on this ship feel free to check them out...\n" +
                    $"C) {cutlass.Name}\n" +
                    $"B) {blunderbuss.Name}\n" +
                    $"H) {hook.Name}\n" +
                    $"P) {pike.Name}\n" +
                    $"S) {shield.Name}\n" +
                    $"E) Exit");
                ConsoleKey userWeapon = Console.ReadKey(true).Key;
                switch (userWeapon)
                {
                    case ConsoleKey.C:
                        player.EquipedWeapon = cutlass;
                        Console.WriteLine(cutlass);
                        break;
                    case ConsoleKey.B:
                        player.EquipedWeapon = blunderbuss;
                        Console.WriteLine(blunderbuss);
                        break;
                    case ConsoleKey.H:
                        player.EquipedWeapon = hook;
                        Console.WriteLine(hook);
                        break;
                    case ConsoleKey.P:
                        player.EquipedWeapon = pike;
                        Console.WriteLine(pike);
                        break;
                    case ConsoleKey.S:
                        player.EquipedWeapon = shield;
                        Console.WriteLine(shield);
                        break;
                    case ConsoleKey.E:
                        isPlayerSureWeapons = true;
                        exit = true;
                        break;                        
                    default:
                        Console.WriteLine("Can't fathom your immense lack of intelect");
                        break;
                }
                Console.WriteLine("Are you sure?\n" +
                                   "Y) Yes\n" +
                                   "N) No\n" +
                                   "E) Exit\n");
                ConsoleKey playerWeaponConfirmation = Console.ReadKey(true).Key;
                switch (playerWeaponConfirmation)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine($"Alright You're set to go good luck but before you go here are your stats\n" +
                            $"{player}\n" +
                            $"Press any key to continue...");
                        Console.ReadKey();
                        isPlayerSureWeapons = true;
                        Console.Clear();
                        break;
                    case ConsoleKey.N:
                        Console.Clear();
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("Makes sense later man");
                        exit = true;
                        isPlayerSureMorals = true;
                        isPlayerSureWeapons = true;
                        loopCount = 0;
                        break;
                    default:
                        Console.WriteLine("You should probably quit man this is a text game and you obvously cant read");
                        break;
                }


            }

            #endregion

            #region Enemy Creation
            Captain luffy = new Captain(100, 100, "Monkey D' Luffy", 50, 30, 25 , 10, "A what looks like a kid but fights like a man", Captain.DrunkGenerator());
            Pirate crew0 = new Pirate(15, 15, "God Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate crew1 = new Pirate(15, 15, "Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate crew2 = new Pirate(15, 15, "Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate crew3 = new Pirate(15, 15, "Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate crew4 = new Pirate(15, 15, "Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate crew5 = new Pirate(15, 15, "Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate crew6 = new Pirate(15, 15, "Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");

            List<Pirate> strawHats = new List<Pirate>()
            {
                crew0,
                crew1,
                crew2,
                crew3,
                crew4,
                crew5,
                crew6,
                luffy
            };
            #endregion

            loopCount = 0;

            #region GamePlay Loop
            while (!exit)
            {

                
                int score = 0;
                if (loopCount == 0)
                {
                    Console.WriteLine($"{boatDescriptions[0]}\n {strawHats[0].Description} jumps down and stands in your way his name is {strawHats[0].Name}\nWhat will you do...");
                    
                }
                if (loopCount == 1)
                {
                    Console.WriteLine($"{boatDescriptions[1]}\n {strawHats[1].Description} stands in your way is name is {strawHats[1].Name}\nWhat will you do...");

                }
                if (loopCount == 2)
                {
                    Console.WriteLine($"{boatDescriptions[2]}\n {strawHats[2].Description} stands in your way is name is {strawHats[2].Name}\nWhat will you do...");

                }
                if (loopCount == 3)
                {
                    Console.WriteLine($"{boatDescriptions[3]}\n {strawHats[3].Description} stands in your way is name is {strawHats[3].Name}\nWhat will you do...");

                }
                if (loopCount == 4)
                {
                    Console.WriteLine($"{boatDescriptions[4]}\n {strawHats[4].Description} stands in your way is name is {strawHats[4].Name}\nWhat will you do...");

                }
                if (loopCount == 5)
                {
                    Console.WriteLine($"{boatDescriptions[5]}\n {strawHats[5].Description} stands in your way is name is {strawHats[5].Name}\nWhat will you do...");

                }
                if (loopCount == 6)
                {
                    Console.WriteLine($"{boatDescriptions[6]}\n {strawHats[6].Description} stands in your way is name is {strawHats[6].Name}\nWhat will you do...");

                }
                if (loopCount == 7)
                {
                    Console.WriteLine($"{boatDescriptions[7]}\n {strawHats[7].Description} stands in your way is name is {strawHats[7].Name}\nWhat will you do...");

                }

                Console.Write("\nPlease choose an action:\n" +
                    "A) Attack\n" +
                    "C) Charm\n" +
                    "R) Run Away\n" +
                    "P) Player Information\n" +
                    "E) Enemy Information\n" +
                    "X) Exit\n");
                ConsoleKey userChoice = Console.ReadKey(true).Key;//Capture the pressed key, hide the key from the console, and execute immediatly
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        break;
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.R:
                        break;
                    case ConsoleKey.P:
                        break;
                    case ConsoleKey.E:      
                        break;
                    case ConsoleKey.X:
                        Console.WriteLine("Yeah id quit too");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Learn to read... Press A) C) R) P) E) or X)");
                        
                        break;
                }
                loopCount++;
            } 
            #endregion
        }
    }
}