using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinder.Models;

namespace pathfinder_rough
{
    class Program
    {

        public static int GenerateRandomAbilityScore(int min = 8)
        {
            var dice = new Random();
            var rolls = new List<int>() { dice.Next(1, 7), dice.Next(1, 7), dice.Next(1, 7), dice.Next(1, 7) };
            return rolls.OrderByDescending(o => o).Take(3).Sum();
        }

        public static void CreateCharacterPrompt()
        {
            Console.WriteLine("Name your Character!");
            var name = Console.ReadLine();
            var player1 = new Character
            {
                Name = name ?? "No Name",
                Strength = GenerateRandomAbilityScore(),
                Constitution = GenerateRandomAbilityScore(),
                Dexterity = GenerateRandomAbilityScore(),
                Intelligence = GenerateRandomAbilityScore(),
                Wisdom = GenerateRandomAbilityScore(),
                Charisma = GenerateRandomAbilityScore(),
            };

            System.Console.WriteLine(player1);

            // 
            var db = new PathfinderContext();

            db.Characters.Add(player1);

            db.SaveChanges();

            System.Console.WriteLine(player1);
        }

        public static void DisplayAllCharacters()
        {
            var db = new PathfinderContext();
            var players = db.Characters;

            foreach (var character in players)
            {
                System.Console.WriteLine(character);
            }
        }


        public static void DisplayOneCharacters()
        {
            var db = new PathfinderContext();
            System.Console.WriteLine("Who?");
            var name = Console.ReadLine().ToLower();

            var player = db.Characters.FirstOrDefault(pl => pl.Name.ToLower() == name);
            var output = player?.ToString() ?? "No Name Found";

            System.Console.WriteLine(output);

        }

        public static void UpdateCharacterStats()
        {
            System.Console.WriteLine("Who do you want to update all stats for?");
            var name = Console.ReadLine().ToLower();
            var db = new PathfinderContext();
            var player = db.Characters.FirstOrDefault(f => f.Name.ToLower() == name);
            if (player == null)
            {
                System.Console.WriteLine("No player found");
            }
            else
            {
                System.Console.WriteLine("before.." + player);

                player.Strength = GenerateRandomAbilityScore();
                player.Dexterity = GenerateRandomAbilityScore();
                player.Constitution = GenerateRandomAbilityScore();
                player.Intelligence = GenerateRandomAbilityScore();
                player.Wisdom = GenerateRandomAbilityScore();
                player.Charisma = GenerateRandomAbilityScore();
                db.SaveChanges();
                System.Console.WriteLine("Updated => " + player);
            }
        }

        public static void DeleteCharacter()
        {
            System.Console.WriteLine("Who do you want to delete?");
            var name = Console.ReadLine().ToLower();
            var db = new PathfinderContext();
            var toDelete = db.Characters.FirstOrDefault(f => f.Name.ToLower() == name);
            if (toDelete == null)
            {
                System.Console.WriteLine("Nothign to delete");
            }
            else
            {
                db.Characters.Remove(toDelete);
                System.Console.WriteLine("Done");
                db.SaveChanges();
            }

        }

        static void Main(string[] args)
        {

            while (true)
            {
                System.Console.WriteLine("---------------------");
                System.Console.WriteLine("Current Players");
                DisplayAllCharacters();
                System.Console.WriteLine("What do you want to do?");
                System.Console.WriteLine("(C)reate?");
                System.Console.WriteLine("(U)pdate character stats?");
                System.Console.WriteLine("(D)elete?");
                var choice = System.Console.ReadLine();
                System.Console.WriteLine("---------------------");

                switch (choice.ToLower())
                {
                    case "c":
                        CreateCharacterPrompt();
                        break;
                    case "u":
                        UpdateCharacterStats();
                        break;
                    case "d":
                        DeleteCharacter();
                        break;
                    default:
                        System.Console.WriteLine("try again");
                        break;
                }
                System.Console.WriteLine("---------------------");
            }

        }
    }
}
