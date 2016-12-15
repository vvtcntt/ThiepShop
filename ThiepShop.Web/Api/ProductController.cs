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
    [RoutePrefix("api/products")]
    [Authorize]

    public class ProductController :  ApiControllerBase
    {
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, int id, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var listProduct = _productService.GetALL();
                if (!string.IsNullOrEmpty(keyword))
                {
                    listProduct = _productService.GetAll(keyword);
                }
                if (id > 0)
                {
                    listProduct = _productService.GetAllById(id);
                }
                totalRow = listProduct.Count();
                var query = listProduct.OrderByDescending(p => p.DateCreate).Skip(page * pageSize).Take(pageSize);
                var responData = Mapper.Map<List<ProductViewModel>>(query);
                var paginationSet = new PaginationSet<ProductViewModel>
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

         
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _productService.GetById(id);
                var responseData = Mapper.Map<Product, ProductViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]

        public HttpResponseMessage create(HttpRequestMessage request, ProductViewModel productVm)
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
                    Sitemaps.CreateSitemap("dsdsd", "33", "sdsd");
                    var newProduct = new Product();
                    newProduct.UpdateProduct(productVm);
                    newProduct.DateCreate = DateTime.Now;
                    _productService.Add(newProduct);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]

        public HttpResponseMessage update(HttpRequestMessage request, ProductViewModel productVm)
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
                    var newProduct = _productService.GetById(productVm.id);
                    newProduct.UpdateProduct(productVm);
                    newProduct.DateCreate = DateTime.Now;

                    _productService.Update(newProduct);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(newProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }
        [Route("updateIdCate")]
        [HttpGet]
        public HttpResponseMessage updateIdCate(HttpRequestMessage request, int id, int idCate)
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
                    var newProduct = _productService.GetById(id);
                    newProduct.idCate = idCate;
                    if (idCate == 0)
                        newProduct.idCate = null;

                    _productService.Update(newProduct);
                    _productService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, newProduct);

                    return response;
                }
                return response;
            });
        }
        [Route("updateMutil")]
        [HttpGet]
        public HttpResponseMessage updateMutil(HttpRequestMessage request, int id,string code=null, bool? active = null, bool? viewhomes = null, int? ord = null,int?price=null,int?pricesale=null)
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
                    var newProduct = _productService.GetById(id);
                    if (active != null)
                    {
                        if (active == true)
                            newProduct.Active = false;
                        else
                            newProduct.Active = true;
                    }

                    if (viewhomes != null)
                    {
                        if (viewhomes == true)
                            newProduct.ViewHomes = false;
                        else
                            newProduct.ViewHomes = true;
                    }
                    if (ord != null)
                    {
                        newProduct.Ord = int.Parse(ord.ToString());
                    }
                    if (price != null)
                    {
                        newProduct.Price = int.Parse(price.ToString());
                    }
                    if (pricesale != null)
                    {
                        newProduct.PriceSale = int.Parse(pricesale.ToString());
                    }
                    if(code!=null)
                    {
                        newProduct.Code = code;
                    }
                    _productService.Update(newProduct);
                    _productService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, newProduct);

                    return response;
                    //Bqanj ơi, mình hết giờ giờ công ty đống cửa. Cám ơn bạn nhé. Mọi người chờ đóng cửa, mai chiến tiếp. Thanks bạn nhiều nhé
                    //ok để tý về mình lục lại đống code xem. l aâku rồi ko làm angular
                }
                return response;
            });
        }
        [Route("GetOrd")]
        [HttpGet]
        public HttpResponseMessage GetOrd(HttpRequestMessage request, string id)
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
                    int ids = int.Parse(id);
                    response = request.CreateResponse(HttpStatusCode.Created, _productService.GetOrd(ids));

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
                    var oldGroupProduct = _productService.Delete(id);
                    _productService.SaveChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(oldGroupProduct);
                    response = request.CreateResponse(HttpStatusCode.OK, responseData);
                }
                return response;
            });
        }
        [Route("deletemuilti")]
        [HttpDelete]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProduct)
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
                    var listProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkedProduct);
                    foreach (var item in listProduct)
                    {
                        _productService.Delete(item);
                    }

                    _productService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK, listProduct.Count);
                }
                return response;
            });
        }
    }
}
