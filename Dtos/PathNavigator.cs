namespace ConectionStrings.Dtos;

public class PathNavigator
{
    public PathNavigator()
    {
        Path = new List<string>();
    }

    public IEnumerable<string> Path { get; set; }
}
