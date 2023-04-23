using System.ComponentModel.DataAnnotations;

namespace ApiDevExtreme.Models;

public class Project
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    public int? LabourCost { get; set; }
    public int? MaterialCost { get; set; }
    public int? StrategyCost { get; set; }
    public int? Revenue { get; set; }
    public string? Country { get; set; }
}

