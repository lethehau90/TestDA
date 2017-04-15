using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Data.Infrastructure;
using DoAn.Model.Models;

namespace DoAn.Data.Repositories
{
    public interface IDonationRepository : IRepository<Donation>
    {

    }
    public class DonationRepository : RepositoryBase<Donation>, IDonationRepository
    {
        public DonationRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
