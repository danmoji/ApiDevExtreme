namespace ApiDevExtreme.Models;

public class Quality
{
    public int Id { get; set; }
    public string? MetricName { get; set; }
    public int? CurrentValue { get; set; }
    public int? TargetValue { get; set; }
    public int? Weight { get; set; }
    public string? Description { get; set; }
}