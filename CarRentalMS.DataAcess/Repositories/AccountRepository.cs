﻿using System.Linq;
using CarRentalMS.DataAccess;
using CarRentalMS.DataAccess.Infrastructure;
using CarRentalMS.DataAccess.Infrastructure.Interfaces;
using CarRentalMS.DataAccess.Repositories.Interfaces;

namespace CarRentalMS.DataAccess.Repositories
{
    public class AccountRepository : GenericRepository<UserAccount>, IAccountRepository
    {
        public AccountRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public UserAccount UserLogin(UserAccount user)
        {
            return DbContext.Set<UserAccount>().Where(x => x.EmailAddress == user.EmailAddress).FirstOrDefault();
        }

    }
}
