namespace compare_healthcare_api.Models;

public class Country
{

  public string Name { get; set; }
  public int Rank { get; set; }
  public int MonthWaitingListDelay { get; set; }
  public int AandEHoursWait { get; set; }
  public object CostOfTreatment { get; set; }
  public string CustomerOpinion { get; set; }
}

//constructor?
    /*
     *
     *   {
         "Country": "United Kingdom",
         "Rank": 36,
         "Average_waiting_list_for_an_operation_in_months": 18,
         "Average_hours_to_be_seen_in_A&E": 8,
         "Cost_of_treatment": {
           "Tax_percentage": 100,
           "Cash_percentage": 0
         },
         "Customer_Opinion": "Long wait, poor services"
       },
       
         {
         "Country": "South Korea",
         "Rank": 7,
         "Average_waiting_list_for_an_operation_in_months": 1,
         "Average_hours_to_be_seen_in_A&E": 1,
         "Cost_of_treatment": {
           "Tax_percentage": 50,
           "Cash_percentage": 50
         },
         "Customer_Opinion": "High; widely regarded as efficient and affordable"
       },
       
        comparison result?
        
}
*/