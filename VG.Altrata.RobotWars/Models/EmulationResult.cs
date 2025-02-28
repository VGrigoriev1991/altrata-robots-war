namespace VG.Altrata.RobotWars.Models;

public record EmulationResult
{
    public required Position Position { get; set; }

    public int PenaltiesCount { get; set; }
}