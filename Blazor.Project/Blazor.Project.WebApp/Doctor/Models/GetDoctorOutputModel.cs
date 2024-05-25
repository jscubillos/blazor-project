using System.Text.Json.Serialization;

namespace Blazor.Project.WebApp.Doctor.Models;

public class GetDoctorOutputModel
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("specialityId")]
    public required int SpecialityId { get; set; }
    
    [JsonPropertyName("speciality")]
    public required string Speciality { get; set; }
    
    [JsonPropertyName("street")]
    public required string Street { get; set; }
    
    [JsonPropertyName("city")]
    public required string City { get; set; }
    
    [JsonPropertyName("state")]
    public required string State { get; set; }
    
    [JsonPropertyName("zipCode")]
    public required string ZipCode { get; set; }
}