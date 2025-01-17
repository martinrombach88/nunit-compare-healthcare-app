namespace compare_healthcare_api.Models;

public class ComparisonResult
{
    public Country BaseCountry { get; set; }
    public Country ComparisonCountry { get; set; }
	//setters should look at base and comparison and automatically set differences
	//set country by lower number of rank (i.e. higher)
	//WinningCountry = BaseCountry.Rank > ComparisonCountry.Rank ? ComparisonCountry.Rank : BaseCountry.Rank
    public string WinningCountry { get; set; }
	//WinnerRankingHigherBy = BaseCountry.Rank - ComparisonCountry.Rank
    public int WinnerRankingHigherBy { get; set; }
	//see above
    public int WinnerWaitingListReduction { get; set; }
	//see above
    public int WinnerAandEHoursReduction { get; set; }
	//WinningOpinion = BaseCountry.Rank > ComparisonCountry.Rank ? $' {Winner.Name] is ' + ComparisonCountry.Opinion : BaseCountry.Opinion
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