using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalMS.DataAccess;

namespace CarRentalMS.Services.Interfaces
{
    public interface IAccountServices
    {
        bool Login(UserAccount user);
        bool Logout();
    }
}
