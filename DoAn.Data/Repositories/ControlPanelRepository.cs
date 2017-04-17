using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Data.Infrastructure;
using DoAn.Model.Models;

namespace DoAn.Data.Repositories
{
    public interface IControlPanelRepository : IRepository<ControlPanel>
    {

    }
    public class ControlPanelRepository : RepositoryBase<ControlPanel>, IControlPanelRepository
    {
        public ControlPanelRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
