using DungeonLibrary;
using System.Diagnostics;
using System.Threading;

namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {

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

                MoralityType userMoral = MoralityType.Neutral;
                try
                {
                    int moral = int.Parse(Console.ReadLine()) - 1;
                    userMoral = (MoralityType)moral;
                }
                catch (Exception e)
                {

                    Console.WriteLine("You're now neutral b-word");

                }
                bool moralityCheck = false;
                while (!moralityCheck)
                {


                    

                        switch (userMoral)
                        {
                            case MoralityType.Lawful_Good:
                                Console.WriteLine("Overall boost to max hp and charm chance");
                                player.Morality = MoralityType.Lawful_Good;
                                moralityCheck = true;

                                break;
                            case MoralityType.Lawful_Neutral:
                                Console.WriteLine("Overall boost to max hp and block");
                                player.Morality = MoralityType.Lawful_Neutral;
                                moralityCheck = true;

                                break;
                            case MoralityType.Lawful_Evil:
                                Console.WriteLine("Overall boost to max hp and hit chance");
                                player.Morality = MoralityType.Lawful_Evil;
                                moralityCheck = true;

                                break;
                            case MoralityType.Chaotic_Good:
                                Console.WriteLine("Overall boost to damage and charm chance");
                                player.Morality = MoralityType.Chaotic_Good;
                                moralityCheck = true;

                                break;
                            case MoralityType.Chaotic_Neutral:
                                Console.WriteLine("Overall boost to damage and block");
                                player.Morality = MoralityType.Chaotic_Neutral;
                                moralityCheck = true;

                                break;
                            case MoralityType.Chaotic_Evil:
                                Console.WriteLine("Overall boost to damage and hit chance");
                                player.Morality = MoralityType.Chaotic_Evil;
                                moralityCheck = true;

                                break;
                            case MoralityType.Neutral:
                                moralityCheck = true;
                                break;
                            
                            
                        }
                    
                    
                }
                Console.WriteLine($"Are you sure you're a {player.Morality.ToString().Replace('_', ' ').ToLower()} individual\n" +
                    "Y) Yes\n" +
                    "N) No\n" +
                    "X) Exit\n");
                string playerMoralityConfirmation = Console.ReadLine().ToLower();
                
                switch (playerMoralityConfirmation)
                {
                    case "y":
                        Console.WriteLine("Ahh now that you've said it it makes sense\nPress any key to continue...");
                        Console.ReadKey();
                        isPlayerSureMorals = true;
                        Console.Clear();
                        break;
                    case "n":
                        Console.Clear();
                        break;
                    case "e":
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
                string userWeapon = Console.ReadLine().ToLower();
                Console.Clear();
                switch (userWeapon)
                {
                    case "c":
                        player.EquipedWeapon = cutlass;
                        Console.WriteLine(cutlass);
                        break;
                    case "b":
                        player.EquipedWeapon = blunderbuss;
                        Console.WriteLine(blunderbuss);
                        break;
                    case "h":
                        player.EquipedWeapon = hook;
                        Console.WriteLine(hook);
                        break;
                    case "p":
                        player.EquipedWeapon = pike;
                        Console.WriteLine(pike);
                        break;
                    case "s":
                        player.EquipedWeapon = shield;
                        Console.WriteLine(shield);
                        break;
                    case "e":
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
                string playerWeaponConfirmation = Console.ReadLine().ToLower();
                switch (playerWeaponConfirmation)
                {
                    case "y":
                        Console.WriteLine($"Alright You're set to go good luck but before you go here are your stats\n" +
                            $"{player}\n" +
                            $"Press any key to continue...");
                        Console.ReadKey();
                        isPlayerSureWeapons = true;
                        Console.Clear();
                        break;
                    case "n":
                        Console.Clear();
                        break;
                    case "e":
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
            Captain luffy = new Captain(50, 50, "Monkey D' Luffy", 50, 30, 25 , 10, "A what looks like a kid but fights like a man", Captain.DrunkGenerator());
            Pirate godUsopp = new Pirate(15, 15, "God Usopp", 90, 25, 10, 5, "A lanky individual who is always complaining");
            Pirate nami = new Pirate(20, 20, "Nami", 40, 30, 14, 6, "A redhead that carries a metalic blue pipe");
            Pirate chopper = new Pirate(38, 38, "Chopper", 45, 45, 15, 7, "A reindeer? Or a human? It's unknown");
            Pirate franky = new Pirate(40, 40, "Franky", 45, 60, 14, 9, "A really american cyborg standing like 8 foot tall and wearing a speedo");
            Pirate brook = new Pirate(35, 35, "Brook", 30, 30, 12, 10, "Singning and dancing with a cane sword this skeliton is");
            Captain zoro = new Captain(45, 45, "Zoro", 50, 50, 19, 9, "Mr. Cool he holds 3 swords and has green hair", Captain.DrunkGenerator());
            Pirate sanji = new Pirate(40, 40, "Sanji", 40, 40, 15, 9, "Blond swooshy hair, curled eyebrows, and a cigarette");

            List<Pirate> strawHats = new List<Pirate>()
            {
                godUsopp,
                chopper,
                nami,
                franky,
                brook,
                sanji,
                zoro,
                luffy
            };
            #endregion
            loopCount = 0;

            #region Boats
            List<string> boatRoomDescriptions = new List<string>()
            {
                "You look around and see a bunch of makeshift weapons... There is a man in the room\nWhat will you do...",
                $"After defeating the last pirate you run into the next room and you see a bunch of medical supplies and {strawHats[loopCount].Description}...\nWhat will you do?",
                $"You run into the next room which seems to be housing a bunch of maps and charts you see {strawHats[loopCount].Description}...\nWhat will you do?",
                $"This part of the ship seems to be a workshop of sorts you see a {strawHats[loopCount].Description} is sitting in a chair...\nWhat will you do?",
                $"This room seems to be a library where you see {strawHats[loopCount].Description}...\nWhat will you do?",
                $"Through the door you finally see light... You stumble out and {strawHats[loopCount].Description} stands in your way...\nWhat will you do?",
                $"The ship is bigger than you thought {strawHats[loopCount].Description} stands in your way...\nWhat will you do?",
                $"You reach the end of the ship without a raft in sight {strawHats[loopCount].Description} stands in your way...\nWhat will you do?",
                
                
            };
            #endregion

            #region GamePlay Loop
            while (!exit)
            {

                
                int score = 0;
                if (loopCount == 0)
                {
                    Console.WriteLine($"{boatRoomDescriptions[0]}");
                    
                }
                if (loopCount == 1)
                {
                    Console.WriteLine($"{boatRoomDescriptions[1]}\n {strawHats[1].Description} stands in your way is name is {strawHats[1].Name}\nWhat will you do...");

                }
                if (loopCount == 2)
                {
                    Console.WriteLine($"{boatRoomDescriptions[2]}\n {strawHats[2].Description} stands in your way is name is {strawHats[2].Name}\nWhat will you do...");

                }
                if (loopCount == 3)
                {
                    Console.WriteLine($"{boatRoomDescriptions[3]}\n {strawHats[3].Description} stands in your way is name is {strawHats[3].Name}\nWhat will you do...");

                }
                if (loopCount == 4)
                {
                    Console.WriteLine($"{boatRoomDescriptions[4]}\n {strawHats[4].Description} stands in your way is name is {strawHats[4].Name}\nWhat will you do...");

                }
                if (loopCount == 5)
                {
                    Console.WriteLine($"{boatRoomDescriptions[5]}\n {strawHats[5].Description} stands in your way is name is {strawHats[5].Name}\nWhat will you do...");

                }
                if (loopCount == 6)
                {
                    Console.WriteLine($"{boatRoomDescriptions[6]}\n {strawHats[6].Description} stands in your way is name is {strawHats[6].Name}\nWhat will you do...");

                }
                if (loopCount == 7)
                {
                    Console.WriteLine($"{boatRoomDescriptions[7]}\n {strawHats[7].Description} stands in your way is name is {strawHats[7].Name}\nWhat will you do...");

                }
                    bool reload = false;
                do
                {
                
                Console.Write("\nPlease choose an action:\n" +
                    "A) Attack\n" +
                    "C) Charm\n" +
                    "R) Run Away\n" +
                    "P) Player Information\n" +
                    "E) Enemy Information\n" +
                    "X) Exit\n");
                ConsoleKey userChoice = Console.ReadKey(true).Key;//Capture the pressed key, hide the key from the console, and execute immediatly
                Console.Clear();
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        //Combat
                        
                        
                        Combat.DoBattle(player, strawHats[loopCount]);
                        if (strawHats[loopCount].Life <= 0)
                        {
                            //Use greent to idicate winning
                            Console.ForegroundColor = ConsoleColor.Green;
                                //update score
                                score += 7;
                                //output the result
                                Console.WriteLine($"\nYou Kocked out {strawHats[loopCount].Name} and gained 7 points you now have {score} points");
                            //Reset the color back to normal
                            Console.ResetColor();
                            
                            
                                bool isShopClosed = false;
                                
                                while (!isShopClosed) 
                                {
                                    
                                    if (score >= 1)
                                    {
                                        if (loopCount == 0)
                                        {
                                            Console.WriteLine("Welcome to the shop after defeating enemies you can purchase upgrades here or refil health\n");
                                        }
                                        Console.WriteLine($"_-_-_- Shop -_-_-_\t\tCurrent Score: {score}\n{player}\n" +
                                            "1) 1 Point Block + 2\n" +
                                            "2) 2 Points Max Health + 3\n" +
                                            "4) 4 Points to refil Health\n" +
                                            "5) 5 Points Min & Max Damage + 1\n" +
                                            "X) Exit");
                                        string userSpend = Console.ReadLine().ToLower();
                                        Console.Clear();
                                        switch (userSpend)
                                        {
                                            case "1":
                                            case "one":
                                                Console.WriteLine("Good Choice Block + 2 has been added");
                                                score -= 1;
                                                player.Block += 2;
                                                break;
                                            case "2":
                                            case "two":
                                                Console.WriteLine("Smart 3 Health Points has Been added to your max health");
                                                score -= 2;
                                                player.MaxLife += 3;
                                                break;
                                            case "4":
                                            case "four":
                                                Console.WriteLine("Playing it safe I see...");
                                                score -= 4;
                                                player.Life = player.MaxLife;
                                                break;
                                            case "5":
                                            case "five":
                                                Console.WriteLine("Watch out big spender over here damage range increased by 1");
                                                score -= 5;
                                                player.EquipedWeapon.MinDamge += 1;
                                                player.EquipedWeapon.MaxDamge += 1;
                                                break;
                                            case "x":
                                                Console.WriteLine("See you next time!");
                                                isShopClosed = true;
                                                break;
                                            default:
                                                Console.WriteLine("I'm not upset just disapointed");
                                                break;
                                        } 
                                    }
                                    else
                                    {
                                        score = 0;
                                        Console.WriteLine($"_-_-_- Shop -_-_-_\t\tCurrent Score: {score}\n{player}\n" +
                                             "X) Exit");
                                        string userSpend = Console.ReadLine().ToLower();
                                        Console.Clear();
                                        switch (userSpend)
                                        {
                                           
                                            case "x":
                                                Console.WriteLine("See you next time!");
                                                isShopClosed = true;
                                                break;
                                            default:
                                                Console.WriteLine("I'm not upset just disapointed");
                                                break;
                                        }
                                    }
                                }
                                //update loop count
                            loopCount++;

                                

                            //leave inner loop
                            reload = true;
                        }
                        

                        break;
                    case ConsoleKey.C:
                            //if player.CharmChance is closer to the number generated charm worked

                            Random rand = new Random();
                            
                            int monsterTolerance = rand.Next(0, 101);
                            int playerCharm = rand.Next(player.CharmChance, 101);
                            int compare = rand.Next(0, 101);
                            if (monsterTolerance -100 > playerCharm -100)
                            {
                                Console.WriteLine($"{strawHats[loopCount].Name} is not impressed");
                            }else if (monsterTolerance -100 < playerCharm - 100)
                            {
                                Console.WriteLine($"{strawHats[loopCount].Name} will let you pass for now");
                                loopCount++;
                            }
                            else
                            {
                                Console.WriteLine($"{strawHats[loopCount]} played you and took his shot when your guard was down...\nYou died better luck next time");
                                exit = true;
                            }
                            break;
                    case ConsoleKey.R:
                            //Run Away - Attack of opportunity
                            Console.WriteLine("Run away");
                            //Monster gets an attack of opportunity
                            Console.WriteLine(strawHats[loopCount].Name + " attacks you as you flee");
                            strawHats[loopCount].HitChance += 100;
                            Combat.DoAttack(strawHats[loopCount], player);
                            Console.WriteLine();//for formatting
                            reload = true;
                            break;
                    case ConsoleKey.P:
                            Console.WriteLine(player);
                            break;
                    case ConsoleKey.E:
                            Console.WriteLine(strawHats[loopCount]);
                        break;
                    case ConsoleKey.X:
                        Console.WriteLine("Yeah I'd quit too");
                        exit = true;
                        reload = true;
                        break;
                    default:
                        Console.WriteLine("Learn to read... Press A) C) R) P) E) or X)");
                        
                        break;
                }
                } while (!reload);
            } 
            #endregion
        }
    }
    public class Music
    {
        static int[] DO = new int[] { 131, 262, 523, 1046 };
        static int[] RE = new int[] { 147, 294, 587, 1174 };
        static int[] MI = new int[] { 165, 330, 659, 1318 };
        static int[] FA = new int[] { 175, 349, 698, 1396 };
        static int[] SO = new int[] { 196, 392, 784, 1568 };
        static int[] LA = new int[] { 220, 440, 880, 1760 };
        static int[] TI = new int[] { 247, 494, 988, 1976 };
        public static void SweetChild()
        {



            
                bool musicExit = false;
            while (!musicExit)
            {
                Console.WriteLine("Press Any key to stop");
                //string userStop = Convert.ToString(Console.Read());
                string userStop = Console.ReadLine();
                if (userStop != null)
            {

                Console.WriteLine("Press any key to continue...");
                Console.Read();
                    musicExit = true;
                
            }
            
                int oct1 = 0;
                int oct2 = 1;
                int oct3 = 2;
                int oct4 = 3;
                for (int i = 0; i < 2; i++)
                {
                    Console.Beep(SO[oct2], 250);
                    Console.Beep(SO[oct3], 250);
                    Console.Beep(RE[oct3], 250);
                    Console.Beep(DO[oct3], 250);
                    Console.Beep(DO[oct4], 250);
                    Console.Beep(RE[oct3], 250);
                    Console.Beep(TI[oct3], 250);
                    Console.Beep(RE[oct3], 250);
                }

                for (int i = 0; i < 2; i++)
                {
                    Console.Beep(LA[oct2], 250);
                    Console.Beep(SO[oct3], 250);
                    Console.Beep(RE[oct3], 250);
                    Console.Beep(DO[oct3], 250);
                    Console.Beep(DO[oct4], 250);
                    Console.Beep(RE[oct3], 250);
                    Console.Beep(TI[oct3], 250);
                    Console.Beep(RE[oct3], 250);
                }

                for (int i = 0; i < 2; i++)
                {
                    Console.Beep(DO[oct3], 250);
                    Console.Beep(SO[oct3], 250);
                    Console.Beep(RE[oct3], 250);
                    Console.Beep(DO[oct3], 250);
                    Console.Beep(DO[oct4], 250);
                    Console.Beep(RE[oct3], 250);
                    Console.Beep(TI[oct3], 250);
                    Console.Beep(RE[oct3], 250);
                }

                Console.Beep(SO[oct2], 250);
                Console.Beep(SO[oct3], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(DO[oct3], 250);
                Console.Beep(DO[oct4], 250);
                Console.Beep(RE[oct3], 250);
                Console.Beep(TI[oct3], 250);
                Console.Beep(RE[oct3], 250);
            
            } 

        }
    }
}