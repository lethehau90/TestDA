using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Model.Models;
using DoAn.Data.Infrastructure;
using DoAn.Data.Repositories;

namespace DoAn.Service
{
    public interface IControlPanelService
    {
        ControlPanel Add(ControlPanel controPanel);
        void Update(ControlPanel contropanel);
        ControlPanel Delete(int id);

        ControlPanel GetById(int id);
        IEnumerable<ControlPanel> GetAll();

        void Save();
    }
    public class ControlPanelService : IControlPanelService
    {
        private IControlPanelRepository _controlPanelRepository;
        private IUnitOfWork _unitOfWork;

        public ControlPanelService(IControlPanelRepository _controlPanelRepository, IUnitOfWork unitOfWork)
        {
            this._controlPanelRepository = _controlPanelRepository;
            this._unitOfWork = unitOfWork;
        }
        public ControlPanel Add(ControlPanel controPanel)
        {
            return _controlPanelRepository.Add(controPanel);
        }

        public ControlPanel Delete(int id)
        {
            return _controlPanelRepository.Delete(id);
        }

        public IEnumerable<ControlPanel> GetAll()
        {
            return _controlPanelRepository.GetAll();
        }

        public ControlPanel GetById(int id)
        {
            return _controlPanelRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ControlPanel contropanel)
        {
            _controlPanelRepository.Update(contropanel);
        }
    }
}
