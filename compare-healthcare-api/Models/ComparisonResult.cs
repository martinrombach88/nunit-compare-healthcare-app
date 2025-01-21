namespace compare_healthcare_api.Models;

public class ComparisonResult
{
    public Country baseCountry { get; set; }
    public Country comparisonCountry { get; set; }
    public string winningCountry { get; set; }
    public int winnerRankingHigherBy { get; set; }
    public double winnerWaitingListReduction { get; set; }
    public double winnerAandEHoursReduction { get; set; }
    public string winnerOpinion { get; set; }

    //how does constructor deal with null values?
    public ComparisonResult(Country baseCountry, Country comparisonCountry)
    {
	    this.baseCountry = baseCountry;
	    this.comparisonCountry = comparisonCountry;
	    this.winningCountry = baseCountry.rank < comparisonCountry.rank
		    ? baseCountry.countryName
		    : comparisonCountry.countryName;
	    //using absolute values only 
	    this.winnerRankingHigherBy = Convert.ToInt32(Math.Abs(baseCountry.rank - comparisonCountry.rank));
	    this.winnerWaitingListReduction =
		    Convert.ToDouble(Math.Abs(baseCountry.monthWaitingListDelay -
		                             comparisonCountry.monthWaitingListDelay)); 
	    this.winnerAandEHoursReduction = Convert.ToDouble(Math.Abs(baseCountry.aAndEHoursWait -
	                                                               comparisonCountry.aAndEHoursWait)); 
	    this.winnerOpinion = baseCountry.rank < comparisonCountry.rank ? baseCountry.customerOpinion : comparisonCountry.customerOpinion;
    }
}