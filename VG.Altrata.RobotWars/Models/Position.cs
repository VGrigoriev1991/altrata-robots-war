using System.Drawing;

namespace VG.Altrata.RobotWars.Models;

public record Position
{
    public required Point Coordinates { get; init; }

    public required Direction Direction { get; init; }
}