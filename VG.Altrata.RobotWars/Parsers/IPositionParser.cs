using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Parsers;

public interface IPositionParser
{
    Position Parse(string position);
}