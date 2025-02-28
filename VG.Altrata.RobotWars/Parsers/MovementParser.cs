using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Parsers;

public class MovementParser : IMovementParser
{
    private readonly Dictionary<char, Movement> _movementDictionary = new()
    {
        { 'L', Movement.Left },
        { 'R', Movement.Right },
        { 'M', Movement.Forward }
    };

    public Movement Parse(char movement) => _movementDictionary[movement];
}