using System;

/*
    This is the main entry point of the Player Tournament game. It handles the initial setup, 
    including welcoming the player, prompting for the number of players, and creating player profiles. 
    It also contains the main game loop that continues until only one player remains.
*/

namespace PlayerTournament
{
    internal class main
    {
        static void Main(string[] args)
        {
            #region Description
            int input = 0;

            Console.Write("Welcome to the ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Player Tournament");
            Console.ResetColor();

            Console.WriteLine(" Game!");
            Console.WriteLine();

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the number of players: ");
                Console.ResetColor();
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    Console.ResetColor();
                }

                if (input % 2 == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter a positive even number of players.");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Press Enter to continue...");
                Console.ResetColor(); Console.ReadLine(); Console.WriteLine();
            } while (input <= 0 || input % 2 == 1);

            Console.Clear();

            #region Player Creation
            for (int i = 0; i < input; i++)
            {
                GameManager.CreatePlayer(i + 1);
            }

            Console.Clear();
            #endregion

            #endregion

            #region Game Loop
            while (GameManager.PlayerCount() != 1)
            {
                GameManager.StartGame();
            }

            Console.ReadLine();
            #endregion
        }
    }
}