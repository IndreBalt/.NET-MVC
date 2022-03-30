using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace User
{
    public class UserModel: IdentityUser
    {
     
        public string FullName { get; set; }
     
        public List<InsurancePolicy> MyPolicies { get; set; }

    }
}
