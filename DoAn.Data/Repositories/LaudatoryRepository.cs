using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Model.Models;
using DoAn.Data.Infrastructure;

namespace DoAn.Data.Repositories
{
    public interface ILaudatoryRepository : IRepository<Laudatory>
    {

    }
    public class LaudatoryRepository : RepositoryBase<Laudatory>, ILaudatoryRepository
    {
        public LaudatoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
