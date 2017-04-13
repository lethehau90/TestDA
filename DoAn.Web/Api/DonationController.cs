using AutoMapper;
using DoAn.Model.Models;
using DoAn.Service;
using DoAn.Web.Infrastructure.Core;
using DoAn.Web.Infrastructure.Extensions;
using DoAn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace DoAn.Web.Api
{
    [RoutePrefix("api/donation")]
    [Authorize]
    public class DonationController : ApiControllerBase
    {
        private IDonationService _donationService;

        public DonationController(IErrorService errorService, IDonationService donationService) : base(errorService)
        {
            this._donationService = donationService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _donationService.GetAll();

                var responseData = Mapper.Map<List<DonationViewModel>>(model.ToList());

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _donationService.GetById(id);
                var responseData = Mapper.Map<Donation, DonationViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, DonationViewModel controPanelVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Donation newDonation = new Donation();
                    newDonation.UpdateDonation(controPanelVM);
                    var page = _donationService.Add(newDonation);
                    _donationService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, page);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, DonationViewModel controPanelVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var DonationDb = _donationService.GetById(controPanelVM.ID);
                    DonationDb.UpdateDonation(controPanelVM);
                    _donationService.Update(DonationDb);
                    _donationService.Save();

                    var responseData = Mapper.Map<Donation, DonationViewModel>(DonationDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldDonation = _donationService.Delete(id);
                    _donationService.Save();
                    var responseData = Mapper.Map<Donation, DonationViewModel>(oldDonation);

                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string listId)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var ids = new JavaScriptSerializer().Deserialize<List<int>>(listId);
                    foreach (var id in ids)
                    {
                        _donationService.Delete(id);
                    }
                    _donationService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, ids.Count);
                }
                return response;
            });
        }

    }
}
