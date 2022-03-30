using Data;
using User;

namespace ServicesInsurances
{
    public class UserService : IUserService
    {
        private readonly InsurancePolicyDbContext _db;
        public UserService(InsurancePolicyDbContext db)
        {
            _db = db;
        }

        public UserModel AddUser(UserModel user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }


    }
}
