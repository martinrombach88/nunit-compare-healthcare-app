namespace compare_healthcare_api.Models;

public class ComparisonResult
{
    public Country BaseCountry { get; set; }
    public Country ComparisonCountry { get; set; }
	//setters should look at base and comparison and automatically set differences
    public string BetterSystemCountry { get; set; }
    public int WinnerRankingHigherBy { get; set; }
    public int WinnerWaitingListReduction { get; set; }
    public int WinnerAandEHoursReduction { get; set; }
    public string WinnerOpinion { get; set; }

/*
    "BaseCountry": "United Kingdom",
    "ComparisonCountry": "South Korea",
    "WinningCountry": "South Korea"
    "WinnerRankingHigherBy": 34
    "WinnerWaitingListReduction": 17
    "WinnerA&EHoursReduction" 7
    "WinnerOpinion: "High; widely regarded as efficient and affordable"
        */
}