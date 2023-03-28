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

    public async Task<ApiResponse<Team>> GetTeams()
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<Team>>(ServerUrl + $"teams");
    }
    public async Task<ApiResponse<Player>> GetPlayers(int page = 0)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<Player>>(ServerUrl + $"players?page={page}&per_page=100");
    }

    public async Task<ApiResponse<List<GameStats>>> GetPlayerStats(Player player, int page = 0)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<GameStats>>>(ServerUrl + $"stats?player_ids[]={player.Id}page={page}&per_page=100");
    }

    public async Task<ApiResponse<List<GameStats>>> GetGameStats(Game game)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<GameStats>>>(ServerUrl + $"stats?game_ids[]={game.Id}");
    }

    public async Task <ApiResponse<List<Game>>> GetTeamSchedule(Team team)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Game>>>(ServerUrl + $"games?seasons[]=2022per_page=100&team_ids[]={team.Id}");
    }

    public async Task<ApiResponse<List<Game>>> GetRecentSchedule(DateTime date)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Game>>>(ServerUrl + $"games?per_page=100&start_date={FormatDate(date.AddDays(-7))}&end_date={FormatDate(date.AddDays(7))}");
    }

    protected virtual HttpClient GetHttpClient()
    {
        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

        return client;
    }

    private string FormatDate(DateTime date)
    {
        return date.ToString("yyyy-MM-dd");
    }
}
