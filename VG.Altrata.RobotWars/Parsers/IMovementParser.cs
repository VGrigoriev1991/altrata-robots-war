using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Parsers;

public interface IMovementParser
{
    Movement Parse(char movement);
}