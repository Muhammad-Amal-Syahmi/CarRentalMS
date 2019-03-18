using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;

namespace CarRentalMS.DataAcess.Repositories.Interfaces
{
    public interface IAccountRepository : IGenericRepository<UserAccount>
    {
        UserAccount UserLogin(UserAccount user);
    }
}
