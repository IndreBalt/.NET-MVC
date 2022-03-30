using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User;

namespace Data
{
    public class InsurancePolicyDbContext : IdentityDbContext<UserModel>
    {

        //public InsurancePolicyDbContext(DbContextOptions<InsurancePolicyDbContext> options) : base(options)
        //{

        //}
        public InsurancePolicyDbContext()
        {

        }
        
        public DbSet<InsurancePolicy> InsiurancePolicies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=.; Database=InsurancePolicyRegistration; Trusted_Connection=True; MultipleActiveResultSets=False");


    }
}
