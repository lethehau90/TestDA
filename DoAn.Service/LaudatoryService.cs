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
    public interface ILaudatoryService
    {
        Laudatory Add(Laudatory Laudatory);
        void Update(Laudatory Laudatory);
        Laudatory Delete(int id);

        Laudatory GetById(int id);
        IEnumerable<Laudatory> GetAll(string keyword);

        void Save();
    }
    public class LaudatoryService : ILaudatoryService
    {
        private ILaudatoryRepository _laudatoryRepository;
        private IUnitOfWork _unitOfWork;

        public LaudatoryService(ILaudatoryRepository laudatoryRepository, IUnitOfWork unitOfWork)
        {
            this._laudatoryRepository = laudatoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public Laudatory Add(Laudatory Laudatory)
        {
            return _laudatoryRepository.Add(Laudatory);
        }

        public Laudatory Delete(int id)
        {
            return _laudatoryRepository.Delete(id);
        }

        public IEnumerable<Laudatory> GetAll(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return _laudatoryRepository.GetAll();
            }
            else
            {
                return _laudatoryRepository.GetMulti(x => x.Name.Contains(keyword));
            }
        }

        public Laudatory GetById(int id)
        {
            return _laudatoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Laudatory Laudatory)
        {
            _laudatoryRepository.Update(Laudatory);
        }
    }
}
