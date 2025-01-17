namespace compare_healthcare_api.Models;

public class Country
{
  private string _name { get; set; }
  private int _rank { get; set; }
  private int _monthWaitingListDelay { get; set; }
  private int _aAndEHoursWait { get; set; }
  private CostOfTreatment _costOfTreatment { get; set; }
  private string _customerOpinion { get; set; }

  public Country(string name, int rank, int monthWaitingListDelay, int aAndEHoursWait, CostOfTreatment costOfTreatment, string customerOpinion) 
	{ _name = name;
	_rank = rank;
	_monthWaitingListDelay = monthWaitingListDelay;
	_aAndEHoursWait = aAndEHoursWait;	
	_costOfTreatment = costOfTreatment;
	_customerOpinion = customerOpinion;
}

public class CostOfTreatment {
	public int TaxPercentage { get; set; }
	public int CashPercentage { get; set; }
}