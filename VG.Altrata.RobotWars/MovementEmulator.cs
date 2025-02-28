using VG.Altrata.RobotWars.Models;
using VG.Altrata.RobotWars.Parsers;
using VG.Altrata.RobotWars.Services;
using VG.Altrata.RobotWars.Validators;

namespace VG.Altrata.RobotWars;

public class MovementEmulator(
    Arena arena,
    IMovementService movementService,
    IMovementParser movementParser,
    IPositionParser positionParser,
    ICoordinatesValidator coordinatesValidator)
    : IMovementEmulator
{
    public EmulationResult Emulate(Position initialPosition, IEnumerable<Movement> movements)
    {
        var result = new EmulationResult
        {
            Position = initialPosition
        };

        foreach (var movement in movements)
        {
            var newPosition = movementService.Move(result.Position, movement);

            if (!coordinatesValidator.IsValid(newPosition.Coordinates, arena))
            {
                result.PenaltiesCount++;
            }
            else
            {
                result.Position = newPosition;
            }
        }

        return result;
    }

    public EmulationResult Emulate(string initialPosition, string movements)
    {
        var parsedInitialPosition = positionParser.Parse(initialPosition);
        var parsedMovements = movements.ToCharArray().Select(movementParser.Parse);

        return Emulate(parsedInitialPosition, parsedMovements);
    }
}