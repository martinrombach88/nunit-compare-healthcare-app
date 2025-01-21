namespace compare_healthcare_api.Models;

public class Country
{
	
	//Conventions Problem:
	//Follow the conventions for private/protected/internal or instead of public fields
	//_name vs Name for internal classes etc
	//https://stackoverflow.com/questions/450238/to-underscore-or-to-not-to-underscore-that-is-the-question
  public string countryName { get; set; }
  public int rank { get; set; }
  public int monthWaitingListDelay { get; set; }
  public float aAndEHoursWait { get; set; }
  public CostOfTreatment costOfTreatment { get; set; }
  public string customerOpinion { get; set; }
}

public class CostOfTreatment {
	public int taxPercentage { get; set; }
	public int cashPercentage { get; set; }
}