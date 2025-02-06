namespace compare_healthcare_api.UserModels
{

    public class AdminUser : User
    {
        //user fields
        //admin true
        //actions should all impact a 'CountrySubmissionController'
        
        /*
         What's best practice for interfaces?

         base class
         * user.name
           user.id
           user.dateAdded

           Admin user - methods, endpoints related to tasks relevant to its role
           user list crud functions
           crud for countries and country submissions
           e.g.
           countrylist edits
           submitted countrylist (crowdsource country healthcare info, approve if correct).
           admin can choose submitted to move to core list
           admin users shouldn't have powers beyond this
         */
    }
}