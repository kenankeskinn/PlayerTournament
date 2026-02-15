using System;
using System.Collections.Generic;

/*
    This class contains the functions we need to manage the process within the game. 
    It includes methods for creating players, starting the game, and handling player matches.
*/

namespace PlayerTournament
{
    internal static class GameManager
    {
        #region Variables
        static Random rand = new Random();

        private static List<Player> players = new List<Player>();
        private static List<Player> matchedPlayers = new List<Player>();
        #endregion

        #region Actioner Methods
        internal static void CreatePlayer(int playerCode)
        {
            Console.Clear();

            string name;
            int health, attack, defense;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player {playerCode}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter the player name: ");
            Console.ResetColor();
            name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nPlayer Attribitues");
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Total of Health, Attack and Defense must be equals 100 !\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the player ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("health");
                Console.ResetColor();
                Console.Write(": ");
                health = Convert.ToInt32(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("attack");
                Console.ResetColor();
                Console.Write(": ");
                attack = Convert.ToInt32(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the player ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("defense");
                Console.ResetColor();
                Console.Write(": ");
                defense = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
            } while ((health + attack + defense != 100) || (health <= 0) || (attack <= 0) || (defense <= 0));

            Player newPlayer = new Player(name, health, attack, defense);
            players.Add(newPlayer);
        }

        internal static void StartGame()
        {
            int rounds = players.Count / 2;

            for (int i = 0; i < rounds; i++)
            {
                Console.Clear();

                Player Player1, Player2;

                Player1 = players[rand.Next(0, players.Count)];

                do
                {
                    Player2 = players[rand.Next(0, players.Count)];
                }
                while (Player2 == Player1);

                // Matches
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"- {Player1.Name} VS {Player2.Name} -");
                Console.ResetColor(); Console.WriteLine();
                
                bool player1Side = SideSelection();

                while (Player1.Health != 0 && Player2.Health != 0)
                {
                    if (player1Side)
                    {
                        Player2.GetDamage(Player1.Attack);
                        player1Side = false;
                    }
                    else
                    {
                        Player1.GetDamage(Player2.Attack);
                        player1Side = true;
                    }
                }

                if (Player1.Health == 0)
                {
                    Console.WriteLine($"\n{Player2.Name} wins the match !\n");
                    DeletePlayersFromList(Player1, Player2);
                    matchedPlayers.Add(Player2);
                    Player2.ResetCharacterStats();
                }
                else
                {
                    Console.WriteLine($"\n{Player1.Name} wins the match !\n");
                    DeletePlayersFromList(Player1, Player2);
                    matchedPlayers.Add(Player1);
                    Player1.ResetCharacterStats();
                }
                Console.Read();
            }

            players = matchedPlayers;

            if (players.Count == 1) Console.WriteLine($"-- {players[0].Name} is the winner of the tournament ! --");
        }
        #endregion

        #region Supporter Methods
        static void DeletePlayersFromList(Player player1, Player player2)
        {
            players.Remove(player1);
            players.Remove(player2);
        }

        static bool SideSelection()
        {
            return rand.Next(0, 2) == 1;
        }

        internal static int PlayerCount()
        {
            return players.Count;
        }
        #endregion
    }
}