using ThiepShop.Model.Model;
using ThiepShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThiepShop.Web.Infrastructure.Extentions
{
    public static class EntityExtenstions
    {
        public static void UpdateGroupProduct(this GroupProduct groupProduct,GroupProductViewModel groupProductViewModel)
        {
     
      
            groupProduct.id = groupProductViewModel.id;
            groupProduct.Name = groupProductViewModel.Name;
            groupProduct.DateCreate = groupProductViewModel.DateCreate;
            groupProduct.Alias = groupProductViewModel.Alias;
            groupProduct.Color = groupProductViewModel.Color;
            groupProduct.iCon = groupProductViewModel.iCon;
            groupProduct.Background = groupProductViewModel.Background;
            groupProduct.Images = groupProductViewModel.Images;
            groupProduct.Priority = groupProductViewModel.Priority;
            groupProduct.Level = groupProductViewModel.Level;
            groupProduct.Tag = groupProductViewModel.Tag;
            groupProduct.Content = groupProductViewModel.Content;
            groupProduct.Keyword = groupProductViewModel.Keyword;
            groupProduct.Description = groupProductViewModel.Description;
            groupProduct.Title = groupProductViewModel.Title;
            groupProduct.ParentID = groupProductViewModel.ParentID;
            groupProduct.Ord = groupProductViewModel.Ord;
            groupProduct.idUser = groupProductViewModel.idUser;
            groupProduct.Active = groupProductViewModel.Active;
          
        }
        public static void UpdateProduct(this Product product,ProductViewModel productViewModel)
        {


            product.id = productViewModel.id;
            product.Name = productViewModel.Name;
            product.DateCreate = productViewModel.DateCreate;
            product.Active = productViewModel.Active;
            product.idUser = productViewModel.idUser;
            product.Ord = productViewModel.Ord;
            product.idCate = productViewModel.idCate;
            product.Code = productViewModel.Code;
            product.Title = productViewModel.Title;
            product.Description = productViewModel.Description;
            product.PriceSale = productViewModel.PriceSale;
            product.PriceSaleString = productViewModel.PriceSaleString;
            product.Price = productViewModel.Price;
            product.PriceString = productViewModel.PriceString;
            product.ImageLinkDetail = productViewModel.ImageLinkDetail;
            product.ImageLinkThumb = productViewModel.ImageLinkThumb;
            product.Tag = productViewModel.Tag;
            product.Parameter = productViewModel.Parameter;
            product.Info = productViewModel.Info;
            product.Content = productViewModel.Content;
            product.Keyword = productViewModel.Keyword;
            product.Parameter = productViewModel.Parameter;
            product.idVideo = productViewModel.idVideo;
            product.Tags = productViewModel.Tags;
            product.Visit = productViewModel.Visit;
            product.ViewHomes = productViewModel.ViewHomes;
            product.New = productViewModel.New;
            product.Priority = productViewModel.Priority;
            product.ProductSale = productViewModel.ProductSale;
            product.Status = productViewModel.Status;
            product.ImageSale = productViewModel.ImageSale;
            product.Size = productViewModel.Size;
            product.Note = productViewModel.Note;
            product.Sale = productViewModel.Sale;
            product.Access = productViewModel.Access;
            product.Transport = productViewModel.Transport;
            product.Warranty = productViewModel.Warranty;
            product.Vat = productViewModel.Vat;
            product.MoreImages = productViewModel.MoreImages;

        }
         

        public static void UpdateCriteria(this Criteria criteria, CritetiaViewModel critetiaViewModel)
        {

            criteria.id = critetiaViewModel.id;
            criteria.Name = critetiaViewModel.Name;
            criteria.DateCreate = critetiaViewModel.DateCreate;
            criteria.Active = critetiaViewModel.Active;
            criteria.Ord = critetiaViewModel.Ord;
            criteria.idUser = critetiaViewModel.idUser;
            criteria.idCate = critetiaViewModel.idCate;
            criteria.Priority = critetiaViewModel.Priority;
            criteria.Style = critetiaViewModel.Style;
           



        }
}
}