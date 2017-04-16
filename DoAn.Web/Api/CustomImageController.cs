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
    [RoutePrefix("api/customimage")]
    [Authorize]
    public class CustomImageController : ApiControllerBase
    {
        private ICustomImageService _customImageService;

        public CustomImageController(IErrorService errorService, ICustomImageService customImageService) : base(errorService)
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
                var responseData = Mapper.Map<CustomImage, CustomImageViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, CustomImageViewModel controPanelVM)
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
                    CustomImage newCustomImage = new CustomImage();
                    newCustomImage.UpdateCustomImage(controPanelVM);
                    newCustomImage.CreatedDate = DateTime.Now;
                    newCustomImage.CreatedBy = User.Identity.Name;
                    var page = _customImageService.Add(newCustomImage);
                    _customImageService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, page);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, CustomImageViewModel controPanelVM)
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
                    var CustomImageDb = _customImageService.GetById(controPanelVM.ID);
                    CustomImageDb.UpdateCustomImage(controPanelVM);
                    CustomImageDb.UpdateDate = DateTime.Now;
                    CustomImageDb.UpdateBy = User.Identity.Name;
                    _customImageService.Update(CustomImageDb);
                    _customImageService.Save();

                    var responseData = Mapper.Map<CustomImage, CustomImageViewModel>(CustomImageDb);
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
                    var oldCustomImage = _customImageService.Delete(id);
                    _customImageService.Save();
                    var responseData = Mapper.Map<CustomImage, CustomImageViewModel>(oldCustomImage);

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
