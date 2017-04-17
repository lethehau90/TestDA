using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Data.Infrastructure;
using DoAn.Model.Models;

namespace DoAn.Data.Repositories
{
    public interface ICustomHeaderRepository :  IRepository<CustomHeader>
    {

    }
    public class CustomHeaderRepository : RepositoryBase<CustomHeader>, ICustomHeaderRepository
    {
        public CustomHeaderRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
