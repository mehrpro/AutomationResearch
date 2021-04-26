using Microsoft.AspNetCore.Identity;

namespace AutomationResearch.Models
{
    public class AppUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public bool Gender { get; set; }

        public string MelliCode { get; set; }


    }
}