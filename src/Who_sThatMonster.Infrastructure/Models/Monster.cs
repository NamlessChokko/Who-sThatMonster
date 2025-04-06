namespace Who_sThatMonster.Web.Models;

public class Monster : IMonster
{
    public int Id { get; set; } = 0;  
    public string Name { get; set; } = string.Empty;
    public string Subname { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Generation { get; set; }
    public string Habitat { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public float Size { get; set; }
    public string Skeleton { get; set; } = string.Empty;
    public List<string> Elements { get; set; } = new(); 
    public int ThreatLevel { get; set; }

    public override string ToString()
    {
        return $"{Name} (ID: {Id}) - {Description}";
    }
    public void Print(){
        Console.WriteLine($"{Name} (ID: {Id}) - {Description}");
        Console.WriteLine($"Generation: {Generation}");
        Console.WriteLine($"Habitat: {Habitat}");
        Console.WriteLine($"Classification: {Classification}");
        Console.WriteLine($"Size: {Size}");
        Console.WriteLine($"Skeleton: {Skeleton}");

        foreach (var element in Elements)
        {
            Console.WriteLine($"Element: {element}");
        }
        Console.WriteLine($"Threat Level: {ThreatLevel}");
    }
}
