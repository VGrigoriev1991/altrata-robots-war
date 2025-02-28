using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars;

public interface IMovementEmulator
{
    public EmulationResult Emulate(Position initialPosition, IEnumerable<Movement> movements);

    public EmulationResult Emulate(string initialPosition, string movements);
}