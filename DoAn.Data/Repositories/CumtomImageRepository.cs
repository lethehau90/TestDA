using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Data.Infrastructure;
using DoAn.Model.Models;

namespace DoAn.Data.Repositories
{
    public interface ICumtomImageRepository :  IRepository<CustomImage>
    {

    }
    public class CumtomImageRepository : RepositoryBase<CustomImage>, ICumtomImageRepository
    {
        public CumtomImageRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
