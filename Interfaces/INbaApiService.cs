namespace NbaStatsMaui.Interfaces;

public interface INbaApiService
{
    Task<ApiResponse<Player>> GetPlayers(int page = 0);

    Task<ApiResponse<List<GameStats>>> GetPlayerStats(Player player, int page = 0, int season = 2022);

    Task<ApiResponse<Team>> GetTeams();

    Task<ApiResponse<List<Game>>> GetTeamSchedule(Team team, int season = 2022);

    Task<ApiResponse<List<GameStats>>> GetGameStats(Game game);

    Task<ApiResponse<List<Game>>> GetGames(DateTime date);

}
