using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThiepShop.Model.Model;

namespace ThiepShop.Data
{
    public class ThiepShopDbContext: IdentityDbContext<ApplicationUser>
    {
        public ThiepShopDbContext()
            : base("ThiepShopConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
         
        protected override void OnModelCreating(DbModelBuilder buider)
        {
            buider.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            buider.Entity<IdentityUserLogin>().HasKey(i => i.UserId);

        }
        public DbSet<Product> Products { set; get; }
        public DbSet<Agency> Agencys { set; get; }
        public DbSet<Banks> Banks { set; get; }
        public DbSet<ColorProduct> ColorProducts { set; get; }
        public DbSet<Competitor> Competitors { set; get; }
        public DbSet<CompetitorHomes> CompetitorHomes { set; get; }
        public DbSet<CompetitorLink> CompetitorLinks { set; get; }
        public DbSet<Config> Configs { set; get; }
        public DbSet<ConnectColorProduct> ConnectColorProducts { set; get; }
        public DbSet<ConnectCriteria> ConnectCriterias { set; get; }
        public DbSet<ConnectGroup> ConnectGroups { set; get; }
        public DbSet<ConnectImages> ConnectImages { set; get; }
        public DbSet<ConnectMenuProduct> ConnectMenuProducts { set; get; }
        public DbSet<ConnectNews> ConnectNews { set; get; }
        public DbSet<ConnectWebs> ConnectWebs { set; get; }
        public DbSet<Contact> Contact { set; get; }
        public DbSet<Criteria> Criterias { set; get; }
        public DbSet<Files> Files { set; get; }
        public DbSet<GroupAgency> GroupAgenceis { set; get; }
        public DbSet<GroupChild> GroupChilds { set; get; }
        public DbSet<GroupImage> GroupImages { set; get; }
        public DbSet<GroupNews> GroupNews { set; get; }
        public DbSet<GroupProduct> GroupProducts { set; get; }
        public DbSet<HistoryLogin> HistoryLogin { set; get; }
        public DbSet<Hotline> Hotlines { set; get; }
        public DbSet<ImageProduct> ImageProducts { set; get; }
        public DbSet<Images> Images { set; get; }
        public DbSet<InfoCriteria> InfoCriterias { set; get; }
        public DbSet<Manufactures> Manufactures { set; get; }
        public DbSet<Maps> Maps { set; get; }
        public DbSet<Module> Modules { set; get; }
        public DbSet<News> News { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Partner> Partners { set; get; }
        public DbSet<ProductCheck> ProductChecks { set; get; }
        public DbSet<ProductConnect> ProductConnect { set; get; }
        public DbSet<ProductSale> ProductSales { set; get; }
        public DbSet<ProductSyn> ProductSyns { set; get; }
        public DbSet<Register> Registers { set; get; }
        public DbSet<Right> Rights { set; get; }
        public DbSet<Support> Supports { set; get; }
        public DbSet<Url> Urls { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Video> Videos { set; get; }
        public DbSet<Web> Webs { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<ProductTags> ProductTags { set; get; }
        public DbSet<Tags> Tags { set; get; }
        public static ThiepShopDbContext Create()
        {
            return new ThiepShopDbContext();
        }
    }
}
