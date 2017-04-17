using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Service;
using AutoMapper;
using DoAn.Model.Models;
using DoAn.Web.Models;

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
            return View();
        }
        public ActionResult Logo()
        {
            var customImageModel = _commonService.getLogo("Logo");
            var customImageViewModel = Mapper.Map<CustomImage, CustomImageViewModel>(customImageModel); 
            return PartialView(customImageViewModel);
        }

        public ActionResult Header()
        {
            return PartialView();
        }

    }
}