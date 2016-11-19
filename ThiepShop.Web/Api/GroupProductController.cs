using ThiepShop.Model.Model;
using ThiepShop.Service;
using ThiepShop.Web.Infrastructure.Core;
using ThiepShop.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ThiepShop.Web.Infrastructure.Extentions;
using System.Linq;
using System;
using System.Web.Script.Serialization;
using AutoMapper;
namespace ThiepShop.Web.Api
{
    [RoutePrefix("api/groupproduct")]
    public class GroupProductController : ApiControllerBase
    {
         IGroupProductService _groupProductService;

        public GroupProductController(IErrorService errorService,IGroupProductService groupProductService) : base(errorService)
        {
            this._groupProductService = groupProductService;
        }
       
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listGroupProduct = _groupProductService.GetAll();
                var listGroupProductVm = Mapper.Map<List<GroupProductViewModel>>(listGroupProduct);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listGroupProductVm);
                return response;
            });
        }
        [Route("getallById")]
        [HttpGet]
        public HttpResponseMessage GetAllById(HttpRequestMessage request,int id, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _groupProductService.GetAllByParentId(id);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.DateCreate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<GroupProduct>, IEnumerable<GroupProductViewModel>>(query);

                var paginationSet = new PaginationSet<GroupProductViewModel>()
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
        [Route("getallParent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _groupProductService.GetAll().OrderBy(x=>x.ParentID);
                var responseData = Mapper.Map<IEnumerable<GroupProduct>, IEnumerable<GroupProductViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getById/{id:int}")]
        public HttpResponseMessage GetByID(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _groupProductService.GetById(id);
                var responseData = Mapper.Map<GroupProduct,GroupProductViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create/{id:int}")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request,int id, GroupProductViewModel groupProductVm)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;
                if(!ModelState.IsValid)
                 {
                     request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                else
                 {
                     var newGroupProduct = new GroupProduct();
                     newGroupProduct.UpdateGroupProduct(groupProductVm);
                     newGroupProduct.DateCreate = DateTime.Now;
                     _groupProductService.Add(newGroupProduct);
                     _groupProductService.Save();
                     var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(newGroupProduct);
                     response = request.CreateResponse(HttpStatusCode.Created, responseData);
                 }
                 return response;
             });
        }
        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, GroupProductViewModel groupProductVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var groupProductDb = _groupProductService.GetById(groupProductVm.id);
                    groupProductDb.DateCreate = DateTime.Now;
                    groupProductDb.UpdateGroupProduct(groupProductVm);
                    _groupProductService.Save();
                    var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(groupProductDb);
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
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldGroupProduct = _groupProductService.Delete(id);                 
                    _groupProductService.Save();
                    var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(oldGroupProduct);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
        [Route("deletemuilti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedGroupProduct)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listGroupProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedGroupProduct);
                    foreach(var item in listGroupProduct)
                    {
                        _groupProductService.Delete(item);
                    }
                  
                    _groupProductService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listGroupProduct.Count);
                }
                return response;
            });
        }
        [Route("GetOrd")]
        [HttpGet]
        public HttpResponseMessage GetOrd(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                       response = request.CreateResponse(HttpStatusCode.Created, _groupProductService.GetOrd());

                  }
                return response;
            });
        }
      
    }
}