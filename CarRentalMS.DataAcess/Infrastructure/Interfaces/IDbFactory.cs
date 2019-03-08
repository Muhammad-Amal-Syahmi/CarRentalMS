using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalMS.DataAcess.Infrastructure.Interfaces
{
    public interface IDbFactory: IDisposable
    {
        AWS_POSTGREQL_TRIALEntities Init();
    }
}
