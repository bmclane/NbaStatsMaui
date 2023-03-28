namespace NbaStatsMaui.Models;

public class GameStats
{

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("ast")]
    public int Ast { get; set; }

    [JsonPropertyName("blk")]
    public int Blk { get; set; }

    [JsonPropertyName("dreb")]
    public int Dreb { get; set; }

    [JsonPropertyName("fg3_pct")]
    public float? Fg3Pct { get; set; }

    [JsonPropertyName("fg3a")]
    public int Fg3a { get; set; }

    [JsonPropertyName("fg3m")]
    public int Fg3m { get; set; }

    [JsonPropertyName("fg_pct")]
    public float? Fg_pct { get; set; }

    [JsonPropertyName("fga")]
    public int Fga { get; set; }

    [JsonPropertyName("fgm")]
    public int Fgm { get; set; }

    [JsonPropertyName("ft_pct")]
    public float? Ft_pct { get; set; }

    [JsonPropertyName("fta")]
    public int Fta { get; set; }

    [JsonPropertyName("ftm")]
    public int Ftm { get; set; }

    [JsonPropertyName("game")]
    public Game Game { get; set; }

    [JsonPropertyName("min")]
    public string Min { get; set; }

    [JsonPropertyName("oreb")]
    public int Oreb { get; set; }

    [JsonPropertyName("pf")]
    public int Pf { get; set; }

    [JsonPropertyName("player")]
    public Player Player { get; set; }

    [JsonPropertyName("pts")]
    public int Pts { get; set; }

    [JsonPropertyName("reb")]
    public int Reb { get; set; }

    [JsonPropertyName("stl")]
    public int Stl { get; set; }

    [JsonPropertyName("team")]
    public Team Team { get; set; }

    [JsonPropertyName("turnover")]
    public int Turnover { get; set; }

    public GameStats()
    { }

    public GameStats(int id, int ast, int blk, int dreb, float fg3Pct, int fg3a, int fg3m, float fg_pct, int fga, int fgm, float ft_pct, int fta, int ftm, Game game, string min, int oreb, int pf, Player player, int pts, int reb, int stl, Team team, int turnover)
    {
        Id = id;
        Ast = ast;
        Blk = blk;
        Dreb = dreb;
        Fg3Pct = fg3Pct;
        Fg3a = fg3a;
        Fg3m = fg3m;
        Fg_pct = fg_pct;
        Fga = fga;
        Fgm = fgm;
        Ft_pct = ft_pct;
        Fta = fta;
        Ftm = ftm;
        Game = game;
        Min = min;
        Oreb = oreb;
        Pf = pf;
        Player = player;
        Pts = pts;
        Reb = reb;
        Stl = stl;
        Team = team;
        Turnover = turnover;
    }
}
