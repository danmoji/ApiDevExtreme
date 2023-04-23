namespace ApiDevExtreme.Models;

public class Flow
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Shortcut { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public int? RangeStart { get; set; }
    public int? RangeEnd { get; set; }
    public int? Value { get; set; }
}

