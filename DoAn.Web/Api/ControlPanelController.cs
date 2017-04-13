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
    [RoutePrefix("api/controlpanel")]
    //[Authorize]
    public class ControlPanelController : ApiControllerBase
    {
        private IControlPanelService _controlPanelService;

        public ControlPanelController(IErrorService errorService, IControlPanelService controlPanelService) : base(errorService)
        {
            this._controlPanelService = controlPanelService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _controlPanelService.GetAll();

                var responseData = Mapper.Map<List<ControlPanelViewModel>>(model.ToList());

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
                var model = _controlPanelService.GetById(id);
                var responseData = Mapper.Map<ControlPanel, ControlPanelViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ControlPanelViewModel controPanelVM)
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
                    ControlPanel newControlPanel = new ControlPanel();
                    newControlPanel.UpdateControlPanel(controPanelVM);
                    var page = _controlPanelService.Add(newControlPanel);
                    _controlPanelService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, page);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, ControlPanelViewModel controPanelVM)
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
                    var ControlPanelDb = _controlPanelService.GetById(controPanelVM.ID);
                    ControlPanelDb.UpdateControlPanel(controPanelVM);
                    _controlPanelService.Update(ControlPanelDb);
                    _controlPanelService.Save();

                    var responseData = Mapper.Map<ControlPanel, ControlPanelViewModel>(ControlPanelDb);
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
                    var oldControlPanel = _controlPanelService.Delete(id);
                    _controlPanelService.Save();
                    var responseData = Mapper.Map<ControlPanel, ControlPanelViewModel>(oldControlPanel);

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
                        _controlPanelService.Delete(id);
                    }
                    _controlPanelService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, ids.Count);
                }
                return response;
            });
        }

    }
}
