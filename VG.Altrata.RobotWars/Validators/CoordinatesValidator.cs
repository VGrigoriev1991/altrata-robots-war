using System.Drawing;
using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Validators;

public class CoordinatesValidator : ICoordinatesValidator
{
    public bool IsValid(Point coordinates, Arena arena)
        => coordinates.X >= 0
           && coordinates.X < arena.Width
           && coordinates.Y >= 0
           && coordinates.Y < arena.Height;
}