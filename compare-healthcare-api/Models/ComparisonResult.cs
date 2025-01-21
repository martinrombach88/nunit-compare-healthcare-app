namespace compare_healthcare_api.Models;

public class ComparisonResult
{
    public Country baseCountry { get; set; }
    public Country comparisonCountry { get; set; }
	//setters should look at base and comparison and automatically set differences
	//set country by lower number of rank (i.e. higher)
	//WinningCountry = BaseCountry.Rank > ComparisonCountry.Rank ? ComparisonCountry.Rank : BaseCountry.Rank
    public string winningCountry { get; set; }
	//WinnerRankingHigherBy = BaseCountry.Rank - ComparisonCountry.Rank
    public int winnerRankingHigherBy { get; set; }
	//see above
    public int winnerWaitingListReduction { get; set; }
	//see above
    public int winnerAandEHoursReduction { get; set; }
	//WinningOpinion = BaseCountry.Rank > ComparisonCountry.Rank ? $' {Winner.Name] is ' + ComparisonCountry.Opinion : BaseCountry.Opinion
    public string winnerOpinion { get; set; }

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