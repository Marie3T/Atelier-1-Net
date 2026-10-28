public class Labyrinth
{
    public Tile[,] tiles;

    public int Width { get; }

    public int Height { get; }

    public Labyrinth(string labyrinth)
    {
        string[] lines = labyrinth.Split('\n');

        Height = lines.Length;
        Width = lines[0].Length;

        tiles = new Tile[Height, Width];
    }
}