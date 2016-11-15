using System;
namespace ThiepShop.Model.Abstract
{
    public interface IAuditable
    {
        int id { set; get; }
        string Name { set; get; }
        DateTime DateCreate { set; get; }
        bool Active { set; get;}
        int idUser { set; get; }
        int Ord { set; get; }
    }
}