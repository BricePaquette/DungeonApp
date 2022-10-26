namespace Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\tYou wake on an anchored ship you hear voices, but before you act you start to remember who you are...");
            bool exit = false;
            #region GamePlay Loop
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
                        break;
                    default:
                        Console.WriteLine("Learn to read... Press A) C) R) P) E) or X)");
                        break;
                }
            } while (!exit);
            #endregion
        }
    }
}