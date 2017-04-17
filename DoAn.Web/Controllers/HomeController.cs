using AutoMapper;
using DoAn.Model.Models;
using DoAn.Service;
using DoAn.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DoAn.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICommonService _commonService;

        public HomeController(ICommonService commonService)
        {
            this._commonService = commonService;
        }

        public ActionResult Index()
        {
            var controlPanelModel = _commonService.getControPanel(2);
            var controlPanelViewModel = Mapper.Map<ControlPanel, ControlPanelViewModel>(controlPanelModel);
            ViewBag.ControPanel = controlPanelViewModel;

            if (controlPanelViewModel != null)
            {
                var donationModel = _commonService.getListDonation();
                ViewBag.donationViewModel = Mapper.Map<IEnumerable<Donation>, IEnumerable<DonationViewModel>>(donationModel);
                return View();
            }
            else
            {
                var laudatoryModel = _commonService.getListLaudatory();
                var laudatoryViewModel = Mapper.Map<IEnumerable<Laudatory>, IEnumerable<LaudatoryViewModel>>(laudatoryModel);
                return View(laudatoryViewModel);
            }
        }

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