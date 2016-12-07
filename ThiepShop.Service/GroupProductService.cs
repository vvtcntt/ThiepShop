using ThiepShop.Data.Infrastructure;
using ThiepShop.Data.Repositories;
using ThiepShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiepShop.Service
{
    public interface IGroupProductService
    {
         void Add(GroupProduct groupProduct);
        void Update(GroupProduct groupProduct);
        GroupProduct Delete(int id);
        IEnumerable<GroupProduct> GetAll();
        IEnumerable<GroupProduct> GetAllByParentId(int parentId);
        GroupProduct GetById(int id);
        void UpdateParentID( int id);
        string GetOrd(string id);
        IEnumerable<GroupProduct> GetAll(string Keyword);
        IEnumerable<GroupProduct> GetAll(int id);

        void Save();
    }
    public class GroupProductService : IGroupProductService
    {
        private IGroupProductRepository _groupProductRepository;
        private IUnitOfWork _unitOfWork;


        public GroupProductService(IGroupProductRepository groupProductRepository, IUnitOfWork unitOfWork)
        {
            this._groupProductRepository = groupProductRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(GroupProduct groupProduct)
        {
            _groupProductRepository.Add(groupProduct);
        }

        public GroupProduct Delete(int id)
        {
           return _groupProductRepository.Delete(id);
        }

        public IEnumerable<GroupProduct> GetAll()
        {
            return _groupProductRepository.GetAll();
        }

        public IEnumerable<GroupProduct> GetAll(string Keyword)
        {
            if (!string.IsNullOrEmpty(Keyword))
            {
                return _groupProductRepository.GetMulti(x => x.Name.Contains(Keyword) || x.Description.Contains(Keyword));

            }
            else
                return _groupProductRepository.GetAll();

        }
        public IEnumerable<GroupProduct> GetAll(int id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return _groupProductRepository.GetMulti(x => x.ParentID==id);

            }
            else
                return _groupProductRepository.GetAll();

        }
        public IEnumerable<GroupProduct> GetAllByParentId(int parentId)
        {
            return _groupProductRepository.GetMulti(x => x.Active == true && x.ParentID == parentId);
        }

        public GroupProduct GetById(int id)
        {
            return _groupProductRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(GroupProduct groupProduct)
        {
            _groupProductRepository.Update(groupProduct);
        }

        public void UpdateParentID( int id)
        {
             
 
        }

        string IGroupProductService.GetOrd(string id)
        {
            
            return _groupProductRepository.Getords(id);
        }
    }
}
