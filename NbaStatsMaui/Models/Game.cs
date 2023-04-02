namespace NbaStatsMaui.Models;

public enum GameStatus
{
    Pregame,
    Active,
    Completed
}

public class Game
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("home_team_id")]
    public int HomeTeamId { get; set; }

    [JsonPropertyName("home_team")]
    public Team? HomeTeam { get; set; }

    [JsonPropertyName("home_team_score")]
    public int HomeTeamScore { get; set; }

    [JsonPropertyName("period")]
    public int Period { get; set; }

    [JsonPropertyName("postseason")]
    public bool Postseason { get; set; }

    [JsonPropertyName("season")]
    public int Season { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("visitor_team_id")]
    public int VisitorTeamId { get; set; }

    [JsonPropertyName("visitor_team")]
    public Team? VisitorTeam { get; set; }

    [JsonPropertyName("visitor_team_score")]
    public int VisitorTeamScore { get; set; }

    [JsonIgnore]
    public DateTime GameStart => GameStatus == GameStatus.Pregame ? DateTime.Parse($"{Date.ToShortDateString()} {Status.Substring(0, Status.Length - 2)}") : Date;

    [JsonIgnore]
    public GameStatus GameStatus
    {
        get
        {
            if (Status.Equals("Final"))
                return GameStatus.Completed;

            if (string.IsNullOrEmpty(Time))
                return GameStatus.Pregame;

            return GameStatus.Active;

        }
    }

    [JsonIgnore]
    public bool Completed => GameStatus == GameStatus.Completed;

    [JsonIgnore]
    public bool Active => GameStatus == GameStatus.Active;

    [JsonIgnore]
    public bool Pregame => GameStatus == GameStatus.Pregame;

    [JsonIgnore]
    public string Title => $"{VisitorTeam.Abbreviation} at {HomeTeam.Abbreviation}";

    public Game(int id, DateTime date, int homeTeamId, Team homeTeam, int homeTeamScore, int period, bool postseason, int season, string status, string time, int visitorTeamId, Team visitorTeam, int visitorTeamScore)
    {
        Id = id;
        Date = date;
        HomeTeamId = homeTeamId;
        HomeTeam = homeTeam;
        HomeTeamScore = homeTeamScore;
        Period = period;
        Postseason = postseason;
        Season = season;
        Status = status;
        Time = time;
        VisitorTeamId = visitorTeamId;
        VisitorTeam = visitorTeam;
        VisitorTeamScore = visitorTeamScore;
    }
}
