using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThiepShop.Model.Model;
using ThiepShop.Web.Models;

namespace ThiepShop.Web.Mappings
{
    public class AutoMaperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GroupProduct, GroupProductViewModel>().MaxDepth(2);
                cfg.CreateMap<Product, ProductViewModel>().MaxDepth(2);

            });
        }
    }
}