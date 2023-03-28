namespace NbaStatsMaui.Models;

public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("meta")]
    public Meta Meta;
}
