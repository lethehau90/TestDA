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
    [RoutePrefix("api/customheader")]
    [Authorize]
    public class CustomHeaderController : ApiControllerBase
    {
        private ICustomHeaderService _customImageService;

        public CustomHeaderController(IErrorService errorService, ICustomHeaderService customImageService) : base(errorService)
        {
            this._customImageService = customImageService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customImageService.GetAll();
                var response = request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _customImageService.GetById(id);
                var responseData = Mapper.Map<CustomHeader, CustomHeaderViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CustomHeaderViewModel customHeaderVM)
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
                    CustomHeader newCustomHeader = new CustomHeader();
                    newCustomHeader.UpdateCustomHeader(customHeaderVM);
                    newCustomHeader.CreatedDate = DateTime.Now;
                    newCustomHeader.CreatedBy = User.Identity.Name;
                    var page = _customImageService.Add(newCustomHeader);
                    _customImageService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, page);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, CustomHeaderViewModel customHeaderVM)
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
                    var CustomHeaderDb = _customImageService.GetById(customHeaderVM.ID);
                    CustomHeaderDb.UpdateCustomHeader(customHeaderVM);
                    CustomHeaderDb.UpdateDate = DateTime.Now;
                    CustomHeaderDb.UpdateBy = User.Identity.Name;
                    _customImageService.Update(CustomHeaderDb);
                    _customImageService.Save();

                    var responseData = Mapper.Map<CustomHeader, CustomHeaderViewModel>(CustomHeaderDb);
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
                    var oldCustomHeader = _customImageService.Delete(id);
                    _customImageService.Save();
                    var responseData = Mapper.Map<CustomHeader, CustomHeaderViewModel>(oldCustomHeader);

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
                        _customImageService.Delete(id);
                    }
                    _customImageService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, ids.Count);
                }
                return response;
            });
        }

    }
}
