using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using ThiepShop.Model.Model;
using ThiepShop.Service;
using ThiepShop.Web.Infrastructure.Core;
using ThiepShop.Web.Infrastructure.Extentions;
using ThiepShop.Web.Models;

namespace ThiepShop.Web.Api
{
    [RoutePrefix("api/groupproduct")]
    [Authorize]
    public class GroupProductController : ApiControllerBase
    {
        private IGroupProductService _groupProductService;

        public GroupProductController(IErrorService errorService, IGroupProductService groupProductService) : base(errorService)
        {
            this._groupProductService = groupProductService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request,int id, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listGroupProduct = _groupProductService.GetAll(keyword).Where(p => p.ParentID == null);
                if (!string.IsNullOrEmpty(keyword))
                {
                    listGroupProduct=_groupProductService.GetAll(keyword);
                }
                    if (id>0)
                {
                    listGroupProduct = _groupProductService.GetAllByParentId(id);
                }
                totalRow = listGroupProduct.Count();
                var query = listGroupProduct.OrderByDescending(p => p.DateCreate).Skip(page * pageSize).Take(pageSize);
                var responData = Mapper.Map<List<GroupProductViewModel>>(query);
                var paginationSet = new PaginationSet<GroupProductViewModel>
                {
                    Items = responData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getallParent")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _groupProductService.GetAll().OrderBy(x => x.ParentID);
                var responseData = Mapper.Map<IEnumerable<GroupProduct>, IEnumerable<GroupProductViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _groupProductService.GetById(id);
                var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage create(HttpRequestMessage request, GroupProductViewModel groupProductVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
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
        public HttpResponseMessage update(HttpRequestMessage request, GroupProductViewModel groupProductVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newGroupProduct = _groupProductService.GetById(groupProductVm.id);
                    newGroupProduct.UpdateGroupProduct(groupProductVm);
                    newGroupProduct.DateCreate = DateTime.Now;

                    _groupProductService.Update(newGroupProduct);
                    _groupProductService.Save();
                    var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(newGroupProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
        [Route("updateMenu")]
        [HttpGet]
        public HttpResponseMessage updateMenu(HttpRequestMessage request,int id,int idParent)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newGroupProduct = _groupProductService.GetById(id);
                    newGroupProduct.ParentID = idParent;
                    if (idParent == 0)
                        newGroupProduct.ParentID = null;

                    _groupProductService.Update(newGroupProduct);
                    _groupProductService.Save();
                     response = request.CreateResponse(HttpStatusCode.OK, newGroupProduct);
                   
                    return response;
                }
                return response;
            });
        }
        [Route("updateMutil")]
        [HttpGet]
        public HttpResponseMessage updateMutil(HttpRequestMessage request, int id, bool? active=null,bool? priority=null, int? ord=null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newGroupProduct = _groupProductService.GetById(id);
                    if (active != null )
                    {
                        if (active == true)
                            newGroupProduct.Active = false;
                        else
                            newGroupProduct.Active = true;
                    }
                       
                    if (priority != null)
                    {
                        if (priority == true)
                            newGroupProduct.Priority = false;
                        else
                            newGroupProduct.Priority = true;
                    }
                    if (ord != null)
                    {
                        newGroupProduct.Ord =int.Parse(ord.ToString());
                    }
                       
                    _groupProductService.Update(newGroupProduct);
                    _groupProductService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, newGroupProduct);

                    return response;
                    //Bqanj ơi, mình hết giờ giờ công ty đống cửa. Cám ơn bạn nhé. Mọi người chờ đóng cửa, mai chiến tiếp. Thanks bạn nhiều nhé
                    //ok để tý về mình lục lại đống code xem. l aâku rồi ko làm angular
                }
                return response;
            });
        }
        [Route("GetOrd")]
        [HttpGet]
        public HttpResponseMessage GetOrd(HttpRequestMessage request,string id)
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
                    response = request.CreateResponse(HttpStatusCode.Created, _groupProductService.GetOrd(id));

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
                    foreach (var item in listGroupProduct)
                    {
                        _groupProductService.Delete(item);
                    }

                    _groupProductService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, listGroupProduct.Count);
                }
                return response;
            });
        }
        //[Route("getallById")]
        //[HttpGet]
        //public HttpResponseMessage GetAllById(HttpRequestMessage request,int id, int page, int pageSize = 20)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        int totalRow = 0;
        //        var model = _groupProductService.GetAllByParentId(id);
        //        totalRow = model.Count();
        //        var query = model.OrderByDescending(x => x.DateCreate).Skip(page * pageSize).Take(pageSize);

        //        var responseData = Mapper.Map<IEnumerable<GroupProduct>, IEnumerable<GroupProductViewModel>>(query);

        //        var paginationSet = new PaginationSet<GroupProductViewModel>()
        //        {
        //            Items = responseData,
        //            Page = page,
        //            TotalCount = totalRow,
        //            TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
        //        };
        //        var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
        //        return response;
        //    });
        //}
        //[Route("getallParent")]
        //[HttpGet]
        //public HttpResponseMessage GetAll(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _groupProductService.GetAll().OrderBy(x=>x.ParentID);
        //        var responseData = Mapper.Map<IEnumerable<GroupProduct>, IEnumerable<GroupProductViewModel>>(model);
        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    });
        //}
        //[Route("getById/{id:int}")]
        //public HttpResponseMessage GetByID(HttpRequestMessage request,int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        var model = _groupProductService.GetById(id);
        //        var responseData = Mapper.Map<GroupProduct,GroupProductViewModel>(model);
        //        var response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        return response;
        //    });
        //}
        //[Route("create/{id:int}")]
        //[HttpPost]
        //[AllowAnonymous]
        //public HttpResponseMessage Create(HttpRequestMessage request,int id, GroupProductViewModel groupProductVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //     {
        //         HttpResponseMessage response = null;
        //        if(!ModelState.IsValid)
        //         {
        //             request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //         }
        //        else
        //         {
        //             var newGroupProduct = new GroupProduct();
        //             newGroupProduct.UpdateGroupProduct(groupProductVm);
        //             newGroupProduct.DateCreate = DateTime.Now;
        //             _groupProductService.Add(newGroupProduct);
        //             _groupProductService.Save();
        //             var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(newGroupProduct);
        //             response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //         }
        //         return response;
        //     });
        //}
        //[Route("update")]
        //[HttpPut]
        //[AllowAnonymous]
        //public HttpResponseMessage Update(HttpRequestMessage request, GroupProductViewModel groupProductVm)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var groupProductDb = _groupProductService.GetById(groupProductVm.id);
        //            groupProductDb.DateCreate = DateTime.Now;
        //            groupProductDb.UpdateGroupProduct(groupProductVm);
        //            _groupProductService.Save();
        //            var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(groupProductDb);
        //            response = request.CreateResponse(HttpStatusCode.Created, responseData);
        //        }
        //        return response;
        //    });
        //}
        //[Route("delete")]
        //[HttpDelete]
        //public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var oldGroupProduct = _groupProductService.Delete(id);
        //            _groupProductService.Save();
        //            var responseData = Mapper.Map<GroupProduct, GroupProductViewModel>(oldGroupProduct);
        //            response = request.CreateResponse(HttpStatusCode.OK, responseData);
        //        }
        //        return response;
        //    });
        //}
        //[Route("deletemuilti")]
        //[HttpDelete]
        //public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedGroupProduct)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //            var listGroupProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedGroupProduct);
        //            foreach(var item in listGroupProduct)
        //            {
        //                _groupProductService.Delete(item);
        //            }

        //            _groupProductService.Save();
        //            response = request.CreateResponse(HttpStatusCode.OK, listGroupProduct.Count);
        //        }
        //        return response;
        //    });
        //}
        //[Route("GetOrd")]
        //[HttpGet]
        //public HttpResponseMessage GetOrd(HttpRequestMessage request)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (!ModelState.IsValid)
        //        {
        //            request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //        }
        //        else
        //        {
        //               response = request.CreateResponse(HttpStatusCode.Created, _groupProductService.GetOrd());

        //          }
        //        return response;
        //    });
        //}
    }
}