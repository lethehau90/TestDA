﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Data.Infrastructure;
using DoAn.Data.Repositories;
using DoAn.Model.Models;

namespace DoAn.Service
{
    public interface ICommonService
    {
        CustomImage getLogo(string type);
        CustomHeader getHeader(string type);
        IEnumerable<Laudatory> getListLaudatory(int pageIndex, int pageSize);
        IEnumerable<Donation> getListDonation(int pageIndex, int pageSize);
        ControlPanel getControPanel(int id);
    }
    public class CommonService : ICommonService
    {
        private ICustomHeaderRepository _customHeaderRepository;
        private ICustomImageRepository _customImageRepository;
        private IDonationRepository _donationRepository;
        private IControlPanelRepository _controlPanelRepository;
        private ILaudatoryRepository _laudatoryRepository;
        private IUnitOfWork _unitOfWork;       

        public CommonService(ICustomHeaderRepository customHeaderRepository,
                             ICustomImageRepository customImageRepository,
                             IDonationRepository donationRepository,
                             IControlPanelRepository controlPanelRepository,
                             ILaudatoryRepository laudatoryRepository,
                             IUnitOfWork unitOfWork)
        {
            this._customHeaderRepository = customHeaderRepository;
            this._customImageRepository = customImageRepository;
            this._donationRepository = donationRepository;
            this._controlPanelRepository = controlPanelRepository;
            this._laudatoryRepository = laudatoryRepository;
            this._unitOfWork = unitOfWork;     
        }

        public CustomImage getLogo(string type)
        {
            return _customImageRepository.GetSingleByCondition(x=>x.Type == type && x.Status);
        }

        public CustomHeader getHeader(string type)
        {
            return _customHeaderRepository.GetSingleByCondition(x => x.Type == type && x.Status);
        }

        public IEnumerable<Laudatory> getListLaudatory(int pageIndex, int pageSize)
        {
            return _laudatoryRepository.GetMulti(x=>x.Status).Skip(pageIndex*pageSize).Take(pageSize);
        }

        public IEnumerable<Donation> getListDonation(int pageIndex, int pageSize)
        {
            return _donationRepository.GetMulti(x => x.Status).Skip(pageIndex * pageSize).Take(pageSize);
        }

        public ControlPanel getControPanel(int id)
        {
            return _controlPanelRepository.GetSingleByCondition(x=>x.ID == id && x.Status);
        }
    }
}
