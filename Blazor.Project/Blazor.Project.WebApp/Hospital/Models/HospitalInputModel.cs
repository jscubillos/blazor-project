using System.ComponentModel.DataAnnotations;

namespace Blazor.Project.WebApp.Hospital.Models;

public class HospitalInputModel
{
    public int? Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Street is required")]
    public string? Street { get; set; }
    
    [Required(ErrorMessage = "City is required")]
    public string? City { get; set; }
    
    [Required(ErrorMessage = "State is required")]
    public string? State { get; set; }
    
    [Required(ErrorMessage = "Zip code is required")]
    public string? ZipCode { get; set; }
}