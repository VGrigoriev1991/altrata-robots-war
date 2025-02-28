using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Parsers;

public interface IDirectionParser
{
    Direction Parse(string direction);
}