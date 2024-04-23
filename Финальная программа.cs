using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp53
{
    static void Main(string[] args)
    {
        Game game = new Game();

        Console.WriteLine("Creating a new character:");
        Console.Write("Enter the character's name: ");
        string имя = Console.ReadLine();

        Console.Write("Enter the character's level: ");
        int level = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the character's health points: ");
        int здоровье = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the character's strength: ");
        int сила = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the character's agility: ");
        int спритность = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the character's intellect: ");
        int интеллект = Convert.ToInt32(Console.ReadLine());

        Character newCharacter = new Character(имя, level, здоровье, сила, спритность, интеллект);
        game.AddCharacter(newCharacter);

        Console.WriteLine("\nCharacteristics of the created character:");
        newCharacter.DisplayInfo();

        string json = JsonSerializer.Serialize(game);
        File.WriteAllText("game_data.json", json);

        Console.WriteLine("\nData saved to game_data.json file");
    }
}

class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intellect { get; set; }
    public List<Item> Inventory { get; set; }

    public Character(string name, int level, int health, int strength, int agility, int intellect)
    {
        Name = name;
        Level = level;
        Health = health;
        Strength = strength;
        Agility = agility;
        Intellect = intellect;
        Inventory = new List<Item>();
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Уровень: {Level}");
        Console.WriteLine($"Здоровье: {Health}");
        Console.WriteLine($"Сила: {Strength}");
        Console.WriteLine($"Спритность: {Agility}");
        Console.WriteLine($"Интеллект: {Intellect}");
    }
}

class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Value { get; set; }
    public int Weight { get; set; }

    public Item(string name, ItemType type, int value, int weight)
    {
        Name = name;
        Type = type;
        Value = value;
        Weight = weight;
    }
}

enum ItemType
{
    Weapon,
    Armor,
    Potion,
}

class Game
{
    public List<Character> Characters { get; set; }
    public List<Item> Items { get; set; }

    public Game()
    {
        Characters = new List<Character>();
        Items = new List<Item>();
    }

    public void AddCharacter(Character character)
    {
        Characters.Add(character);
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }
}