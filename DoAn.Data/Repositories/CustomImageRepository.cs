using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Data.Infrastructure;
using DoAn.Model.Models;

namespace DoAn.Data.Repositories
{
    public interface ICustomImageRepository :  IRepository<CustomImage>
    {

    }
    public class CustomImageRepository : RepositoryBase<CustomImage>, ICustomImageRepository
    {
        public CustomImageRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
