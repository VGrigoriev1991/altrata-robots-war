using System.Drawing;
using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Validators;

public interface ICoordinatesValidator
{
    bool IsValid(Point coordinates, Arena arena);
}