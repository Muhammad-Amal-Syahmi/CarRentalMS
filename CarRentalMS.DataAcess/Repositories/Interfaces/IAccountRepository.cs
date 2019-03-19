using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;

namespace CarRentalMS.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository : IGenericRepository<UserAccount>
    {
        UserAccount UserLogin(UserAccount user);
    }
}
