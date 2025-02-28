using FluentAssertions;
using VG.Altrata.RobotWars.Models;
using VG.Altrata.RobotWars.Parsers;
using VG.Altrata.RobotWars.Services;
using VG.Altrata.RobotWars.Validators;
using Xunit;

namespace VG.Altrata.RobotWars.UnitTests.Services;

public class MovementEmulatorTests
{
    [Theory]
    [InlineData(5, 5, "0, 2, E", "MLMRMMMRMMRR", "4, 1, N", 0)]
    [InlineData(5, 5, "4, 4, S", "LMLLMMLMMMRMM", "0, 1, W", 1)]
    [InlineData(5, 5, "2, 2, W", "MLMLMLMRMRMRMRM", "2, 2, N", 0)]
    [InlineData(5, 5, "1, 3, N", "MMLMMLMMMMM", "0, 0, S", 3)]
    public void Emulate_ValidInput_EmulationResultReturned(
        ushort arenaWidth,
        ushort arenaHeight,
        string initialPosition,
        string movements,
        string expectedPosition,
        int expectedPenaltiesCount)
    {
        // Arrange
        var arena = new Arena
        {
            Width = arenaWidth,
            Height = arenaHeight
        };
        var movementService = new MovementService();
        var movementParser = new MovementParser();
        var directionParser = new DirectionParser();
        var positionParser = new PositionParser(directionParser);
        var coordinatesValidator = new CoordinatesValidator();
        var emulator = new MovementEmulator(
            arena,
            movementService,
            movementParser,
            positionParser,
            coordinatesValidator);

        var parsedExpectedPosition = positionParser.Parse(expectedPosition);

        // Act
        var result = emulator.Emulate(initialPosition, movements);

        //Assert
        result.Position.Coordinates.X.Should().Be(parsedExpectedPosition.Coordinates.X);
        result.Position.Coordinates.Y.Should().Be(parsedExpectedPosition.Coordinates.Y);
        result.Position.Direction.Should().Be(parsedExpectedPosition.Direction);
        result.PenaltiesCount.Should().Be(expectedPenaltiesCount);
    }
}