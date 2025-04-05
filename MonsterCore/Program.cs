using Who_sThatMonster.Models;

namespace Who_sThatMonster;

public class Program
{
    public static void Main(string[] args)
    {
        Monster monster = new();
        monster.Name = "Rathalos"; 
        monster.Subname = "Sky king";
        monster.Description = "A massive, winged, flying, humanoid monster with a large head, a long neck, and a tail.";
        monster.Generation = 1;
        monster.Habitat = "Volcanic";
        monster.Classification = "Bird";
        monster.Size = 240f;
        monster.Skeleton = "Rathalos";
    }
}