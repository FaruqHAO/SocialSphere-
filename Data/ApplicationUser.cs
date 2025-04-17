using Microsoft.AspNetCore.Identity;

namespace DemoApplication.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? createdOn { get; set; }
        public bool status { get; set; }

    }
}
