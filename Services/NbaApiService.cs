using System.Net.Http.Json;

namespace NbaStatsMaui.Services;

public class NbaApiService : INbaApiService
{
    internal readonly string ServerUrl = "https://balldontlie.io/api/v1/";
    internal JsonSerializerOptions options;
    private readonly HttpClient httpClient;

    public NbaApiService()
    {

        httpClient = GetHttpClient();
        options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;

    }

    public async Task<ApiResponse<List<GameStats>>> GetGameStats(Game game)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<GameStats>>>(ServerUrl + $"stats?game_ids[]={game.Id}");
    }

    public async Task<ApiResponse<List<Game>>> GetScheduleForDate(DateTime date)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Game>>>(ServerUrl + $"games?dates[]={date.ToString("yyyy-MM-dd")}");
    }

    protected virtual HttpClient GetHttpClient()
    {
        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

        return client;
    }
}
