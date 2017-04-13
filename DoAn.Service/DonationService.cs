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
    public interface IDonationService
    {
        Donation Add(Donation donation);
        void Update(Donation donation);
        Donation Delete(int id);

        Donation GetById(int id);
        IEnumerable<Donation> GetAll();

        void Save();
    }
    public class DonationService : IDonationService
    {
        private IDonationRepository _donationRepository;
        private IUnitOfWork _unitOfWork;

        public DonationService(IDonationRepository donationRepository, IUnitOfWork unitOfWork)
        {
            this._donationRepository = donationRepository;
            this._unitOfWork = unitOfWork;
        }
        public Donation Add(Donation donation)
        {
            return _donationRepository.Add(donation);
        }

        public Donation Delete(int id)
        {
            return _donationRepository.Delete(id);
        }

        public IEnumerable<Donation> GetAll()
        {
            return _donationRepository.GetAll();
        }

        public Donation GetById(int id)
        {
            return _donationRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Donation donation)
        {
             _donationRepository.Update(donation);
        }
    }
}
