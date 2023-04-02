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

    public async Task<ApiResponse<List<Team>>> GetTeams()
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Team>>>(ServerUrl + $"teams");
    }
    public async Task<ApiResponse<List<Player>>> SearchPlayers(string text)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Player>>>(ServerUrl + $"players?search={text}&per_page=100");
    }

    public async Task<ApiResponse<List<GameStats>>> GetPlayerStats(Player player, int page = 0, int season = 2022)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<GameStats>>>(ServerUrl + $"stats?seasons[]={season}&player_ids[]={player.Id}page={page}&per_page=100");
    }

    public async Task<ApiResponse<List<GameStats>>> GetGameStats(Game game)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<GameStats>>>(ServerUrl + $"stats?game_ids[]={game.Id}&per_page=100");
    }

    public async Task <ApiResponse<List<Game>>> GetTeamSchedule(Team team, int season = 2022)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Game>>>(ServerUrl + $"games?seasons[]={season}&team_ids[]={team.Id}&per_page=100");
    }

    public async Task<ApiResponse<List<Game>>> GetGames(DateTime date)
    {
        return await httpClient.GetFromJsonAsync<ApiResponse<List<Game>>>(ServerUrl + $"games?dates[]={FormatDate(date)}&per_page=100");
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
