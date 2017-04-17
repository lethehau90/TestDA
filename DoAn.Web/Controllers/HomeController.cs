using AutoMapper;
using DoAn.Model.Models;
using DoAn.Service;
using DoAn.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DoAn.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICommonService _commonService;
        private IDonationService _donationService;

        public HomeController(ICommonService commonService, IDonationService donationService)
        {
            this._commonService = commonService;
            this._donationService = donationService;
        }

        private int pageSize = 15;

        public ActionResult Index()
        {
            var controlPanelModel = _commonService.getControPanel(2);
            var controlPanelViewModel = Mapper.Map<ControlPanel, ControlPanelViewModel>(controlPanelModel);
            var getAll = _donationService.GetAll(null);

            decimal? sum = 0;
            foreach (var item in getAll)
            {
                sum = sum + item.Price;
            }
            ViewBag.sum = sum;
            return View(controlPanelViewModel);
        }

        public ActionResult getDonation(int pageIndex, int pageSize)
        {
            var donationModel = _commonService.getListDonation(pageIndex, pageSize);
            var donationViewModel = Mapper.Map<IEnumerable<Donation>, IEnumerable<DonationViewModel>>(donationModel);
            return Json(donationViewModel.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getLaudatories(int pageIndex, int pageSize)
        {
            var laudatoryModel = _commonService.getListLaudatory(pageIndex, pageSize);
            var laudatoryViewModel = Mapper.Map<IEnumerable<Laudatory>, IEnumerable<LaudatoryViewModel>>(laudatoryModel);
            return Json(laudatoryViewModel.ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// ///////////////////
        /// </summary>
        /// <returns></returns>

        public ActionResult Logo()
        {
            var customImageModel = _commonService.getLogo("Logo");
            var customImageViewModel = Mapper.Map<CustomImage, CustomImageViewModel>(customImageModel);
            return PartialView(customImageViewModel);
        }

        public ActionResult Header()
        {
            var customHeaderModel = _commonService.getHeader("Header");
            var customHeaderViewModel = Mapper.Map<CustomHeader, CustomHeaderViewModel>(customHeaderModel);
            return PartialView(customHeaderViewModel);
        }

        public ActionResult Background()
        {
            var customImageModel = _commonService.getLogo("Background");
            var customHeaderViewModel = Mapper.Map<CustomImage, CustomImageViewModel>(customImageModel);
            return PartialView(customHeaderViewModel);
        }
    }
}