using DoAn.Data.Infrastructure;
using DoAn.Data.Repositories;
using DoAn.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Service
{
    public interface ICustomHeaderService
    {
        CustomHeader Add(CustomHeader customHeader);
        void Update(CustomHeader customHeader);
        CustomHeader Delete(int id);
        CustomHeader GetById(int id);
        IEnumerable<CustomHeader> GetAll();
        void Save();
    }
    public class CustomHeaderService : ICustomHeaderService
    {
        private ICustomHeaderRepository _customHeaderRepository;
        private IUnitOfWork _unitOfWork;
        public CustomHeaderService(ICustomHeaderRepository customHeaderRepository, IUnitOfWork unitOfWork)
        {
            this._customHeaderRepository = customHeaderRepository;
            this._unitOfWork = unitOfWork;
        }

        public CustomHeader Add(CustomHeader customHeader)
        {
            return _customHeaderRepository.Add(customHeader);
        }

        public CustomHeader Delete(int id)
        {
            return _customHeaderRepository.Delete(id);
        }

        public IEnumerable<CustomHeader> GetAll()
        {
            return _customHeaderRepository.GetAll();
        }

        public CustomHeader GetById(int id)
        {
            return _customHeaderRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CustomHeader customHeader)
        {
            _customHeaderRepository.Update(customHeader);
        }
    }
}
