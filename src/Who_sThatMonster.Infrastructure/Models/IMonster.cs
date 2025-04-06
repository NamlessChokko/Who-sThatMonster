namespace Who_sThatMonster.Infrastructure.Models;

public interface IMonster
{
    int Id { get; set; }
    string Name { get; set; }
    string Subname { get; set; }
    string Description { get; set; }
    int Generation { get; set; }
    List<string> Habitat { get; set; }
    string Classification { get; set; }
    float Size { get; set; }
    string Skeleton { get; set; }
    List<string> Elements { get; set; }
    int ThreatLevel { get; set; }

    string ToString(); 
}
