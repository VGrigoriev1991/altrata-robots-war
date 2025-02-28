using System.Drawing;
using VG.Altrata.RobotWars.Models;

namespace VG.Altrata.RobotWars.Services;

public class MovementService : IMovementService
{
    private readonly Dictionary<Direction, Point> _moves = new()
    {
        { Direction.North, new Point(0, 1) },
        { Direction.East, new Point(1, 0) },
        { Direction.South, new Point(0, -1) },
        { Direction.West, new Point(-1, 0) }
    };

    public Position Move(Position position, Movement movement)
        =>
            movement switch
            {
                Movement.Left => position with { Direction = (Direction)(((int)position.Direction + 3) % 4) },
                Movement.Right => position with { Direction = (Direction)(((int)position.Direction + 1) % 4) },
                Movement.Forward => Move(position),
                _ => throw new ArgumentOutOfRangeException(nameof(movement), movement, null)
            };

    public Position Move(Position position)
        => position with
        {
            Coordinates = new Point(position.Coordinates.X + _moves[position.Direction].X,
                position.Coordinates.Y + _moves[position.Direction].Y)
        };
}