using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Parsers;

public class DirectionParser : IDirectionParser
{
    private readonly Dictionary<string, Direction> _directionsDictionary = new()
    {
        { "N", Direction.North },
        { "E", Direction.East },
        { "S", Direction.South },
        { "W", Direction.West }
    };

    public Direction Parse(string direction) => _directionsDictionary[direction];
}