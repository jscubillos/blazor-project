using System.Text.Json.Serialization;

namespace Blazor.Project.WebApp.Hospital.Models;

public class GetHospitalOutputModel
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("street")]
    public required string Street { get; set; }
    
    [JsonPropertyName("city")]
    public required string City { get; set; }
    
    [JsonPropertyName("state")]
    public required string State { get; set; }
    
    [JsonPropertyName("zipCode")]
    public required string ZipCode { get; set; }
}