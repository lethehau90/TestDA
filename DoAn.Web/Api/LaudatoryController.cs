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
    [RoutePrefix("api/laudatory")]
    [Authorize]
    public class LaudatoryController : ApiControllerBase
    {
        private ILaudatoryService _laudatoryService;

        public LaudatoryController(IErrorService errorService, ILaudatoryService laudatoryService) : base(errorService)
        {
            this._laudatoryService = laudatoryService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var model = _laudatoryService.GetAll(keyword);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<List<LaudatoryViewModel>>(query.ToList());

                var paginationSet = new PaginationSet<LaudatoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _laudatoryService.GetById(id);
                var responseData = Mapper.Map<Laudatory, LaudatoryViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LaudatoryViewModel controPanelVM)
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
                    Laudatory newLaudatory = new Laudatory();
                    newLaudatory.UpdateLaudatory(controPanelVM);
                    newLaudatory.CreatedDate = DateTime.Now;
                    newLaudatory.CreatedBy = User.Identity.Name;
                    var page = _laudatoryService.Add(newLaudatory);
                    _laudatoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, page);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, LaudatoryViewModel controPanelVM)
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
                    var LaudatoryDb = _laudatoryService.GetById(controPanelVM.ID);
                    LaudatoryDb.UpdateLaudatory(controPanelVM);
                    LaudatoryDb.UpdateDate = DateTime.Now;
                    LaudatoryDb.UpdateBy = User.Identity.Name;
                    _laudatoryService.Update(LaudatoryDb);
                    _laudatoryService.Save();

                    var responseData = Mapper.Map<Laudatory, LaudatoryViewModel>(LaudatoryDb);
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
                    var oldLaudatory = _laudatoryService.Delete(id);
                    _laudatoryService.Save();
                    var responseData = Mapper.Map<Laudatory, LaudatoryViewModel>(oldLaudatory);

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
                        _laudatoryService.Delete(id);
                    }
                    _laudatoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, ids.Count);
                }
                return response;
            });
        }

    }
}
