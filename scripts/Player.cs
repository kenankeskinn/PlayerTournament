using System;

/* 
    This class represents a player in the tournament. 
    It contains attributes such as name, health, attack, and defense, 
    as well as methods to handle damage and reset character stats.
*/

namespace PlayerTournament
{
    internal class Player
    {
        #region Attributes
        // Constructor to initialize the player's attributes
        internal Player(string name, int maxHealth, int attack, int defense)
        {
            this.name = name;
            this.maxHealth = maxHealth;
            this.attack = attack;
            this.defense = defense;
            health = this.maxHealth;
            maxDefense = this.defense;
        }

        // Player attributes
        private string name;
        private int attack;
        private int defense;
        private int health;
        private int maxHealth;
        private int maxDefense;

        internal string Name { get { return name; } }
        internal int Attack { get { return attack; } }
        internal int Defense
        { 
            get { return defense; } 
            set 
            {
                if (value < 0) value = 0;
                defense = value;
            } 
        }
        internal int Health 
        { 
            get { return health; }
            set 
            {
                if (value < 0) value = 0;
                health = value;
            }
        }
        internal int MaxHealth { get { return maxHealth; } }
        internal int MaxDefense { get { return maxDefense; } }

        #endregion

        #region Actions
        internal void GetDamage(int attack)
        {
            int damage = attack - Defense;
            Defense = Defense - attack;

            if (damage < 0) damage = 0;

            Health -= damage;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Name);
            Console.ResetColor();
            Console.WriteLine($"{damage} damage taken !\nHealth: {Health}/{MaxHealth}\nDefense: {Defense}/{MaxDefense}");
            Console.ReadLine();
        }

        internal void ResetCharacterStats()
        {
            Defense = MaxDefense;
        }
        #endregion
    }
}