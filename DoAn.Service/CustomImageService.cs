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
    public interface ICustomImageService
    {
        CustomImage Add(CustomImage customImage);
        void Update(CustomImage customImage);
        CustomImage Delete(int id);
        CustomImage GetById(int id);
        IEnumerable<CustomImage> GetAll();
        void Save();
    }
    public class CustomImageService : ICustomImageService
    {
        private ICustomImageRepository _customImageRepository;
        private IUnitOfWork _unitOfWork;
        public CustomImageService(ICustomImageRepository customImageRepository, IUnitOfWork unitOfWork)
        {
            this._customImageRepository = customImageRepository;
            this._unitOfWork = unitOfWork;
        }

        public CustomImage Add(CustomImage customImage)
        {
            return _customImageRepository.Add(customImage);
        }

        public CustomImage Delete(int id)
        {
            return _customImageRepository.Delete(id);
        }

        public IEnumerable<CustomImage> GetAll()
        {
            return _customImageRepository.GetAll();
        }

        public CustomImage GetById(int id)
        {
            return _customImageRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CustomImage customImage)
        {
            _customImageRepository.Update(customImage);
        }
    }
}
