using System;

namespace PlayerTournament
{
    internal class main
    {
        static void Main(string[] args)
        {
            #region Description
            int input = 0;

            do
            {
                Console.WriteLine("Welcome to the Player Tournament Game!");
                Console.Write("Enter the number of players: ");
                try
                {
                    // 2 nin katları kadar oyuncu girmesi gerekiyor. Düzenlenecek !
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }

                if (input % 2 == 1) Console.WriteLine("Please enter a positive even number of players.");
                
                Console.ReadLine();
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