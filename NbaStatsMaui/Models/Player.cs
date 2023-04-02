namespace NbaStatsMaui.Models;

public class Player
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("height_feet")]
    public int? HeightFeet { get; set; }

    [JsonPropertyName("height_inches")]
    public int? HeightInches { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("position")]
    public string Position { get; set; }

    [JsonPropertyName("team_id")]
    public int TeamId { get; set; }

    [JsonPropertyName("weight_pounds")]
    public int? WeightPounds { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}