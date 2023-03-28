namespace NbaStatsMaui.Interfaces;

public interface INbaApiService
{
    Task<ApiResponse<List<GameStats>>> GetGameStats(Game game);

    Task<ApiResponse<List<Game>>> GetScheduleForDate(DateTime date);
}
