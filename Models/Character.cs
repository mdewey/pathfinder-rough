namespace Pathfinder.Models
{
    public class Character
    {
        public int Id { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }

        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Str:{Strength}, Dex:{Dexterity}, Con: {Constitution}, Wis:{Wisdom}, Int:{Intelligence}, Cha: {Charisma}";
        }
    }
}