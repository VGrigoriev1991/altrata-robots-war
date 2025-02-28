using System.Drawing;
using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Parsers;

public class PositionParser(IDirectionParser directionParser) : IPositionParser
{
    public Position Parse(string position)
    {
        var parts = position
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToArray();

        if (parts.Length != 3
            || !ushort.TryParse(parts[0], out var x)
            || !ushort.TryParse(parts[1], out var y))
        {
            throw new ArgumentException("Invalid position format");
        }

        return new Position
        {
            Coordinates = new Point(x, y),
            Direction = directionParser.Parse(parts[2])
        };
    }
}