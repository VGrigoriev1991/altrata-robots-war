using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Services;

public interface IMovementService
{
    Position Move(Position position, Movement movement);

    Position Move(Position position);
}