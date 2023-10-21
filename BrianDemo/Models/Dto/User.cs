using System.ComponentModel.DataAnnotations;

namespace BrianDemo.Models.Dto;

public class User
{
    [Key] 
    public int? Id { get; set; }

    public string Account { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Birthday { get; set; }
    public string? Mobile { get; set; }
    public DateTime BuildDate { get; set; }
    public int BuildUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public int UpdateUser { get; set; }
}