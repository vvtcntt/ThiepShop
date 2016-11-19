using ThiepShop.Common;
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
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        string GetOrd(int idCate);
        Product Delete(int id);
        IEnumerable<Product> GetALL();
        IEnumerable<Product> GetAll(string Keyword);

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totallRow);
        Product GetById(int id);
        IEnumerable<Product> GetAllByIdPaging(int idCate, int page, int pageSize, out int totallRow);

        IEnumerable<Product> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;
        ITagsRepository _tagRepository;
        IProductTagsRepository _iProductTagsRepository;
        public ProductService(IProductRepository productRepository,ITagsRepository tagRepository,IProductTagsRepository productTagRepository  ,IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._tagRepository = _tagRepository;
            this._iProductTagsRepository = productTagRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Product product)
        {
            _productRepository.Add(product);
            _unitOfWork.Commit();
            if(!string.IsNullOrEmpty(product.Tags))
            {
                string[] Tags = product.Tags.Split(',');
                for(int i=0;i< Tags.Length;i++)
                {
                    var tagid = StringHelper.ToUnsignString(Tags[i]);
                    if(_tagRepository.Count(x=>x.Name.Contains(Tags[i]))==0)
                    {
                        Tags tags = new Tags();
                        tags.Name = Tags[i];
                        tags.Type = CommonConstants.ProductType;
                        _tagRepository.Add(tags);
                    }
                   

                    ProductTags productTags = new ProductTags();
                    productTags.idProduct = product.id;
                    productTags.idTags = tagid;
                    _iProductTagsRepository.Add(productTags);
                }
                
            }
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetALL()
        {
            return _productRepository.GetAll(new string[] { "GroupProduct" });
        }

        public IEnumerable<Product> GetAll(string Keyword)
        {
            if (!string.IsNullOrEmpty(Keyword))
            {
                return _productRepository.GetMulti(x => x.Name.Contains(Keyword) || x.Description.Contains(Keyword));

            }
            else
                return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByIdPaging(int idCate, int page, int pageSize, out int totallRow)
        {
            return _productRepository.GetMultiPaging(x=>x.Active && x.idCate== idCate,out totallRow,page,pageSize,new string[] {"GroupProduct" });
         }

        public IEnumerable<Product> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetAllByTag(tag, page, pageSize, out totalRow);
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productRepository.GetMultiPaging(x => x.Active, out totalRow, page, pageSize);
        }

        public Product GetById(int id)
        {
          return  _productRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
            if (!string.IsNullOrEmpty(product.Tags))
            {
                string[] Tags = product.Tags.Split(',');
                for (int i = 0; i < Tags.Length; i++)
                {
                    var tagid = StringHelper.ToUnsignString(Tags[i]);
                    if (_tagRepository.Count(x => x.Name.Contains(Tags[i])) == 0)
                    {
                        Tags tags = new Tags();
                        tags.Name = Tags[i];
                        tags.Type = CommonConstants.ProductType;
                        _tagRepository.Add(tags);
                    }
                    _iProductTagsRepository.DeleteMulti(x => x.idProduct == product.id);
                    ProductTags productTags = new ProductTags();
                    productTags.idProduct = product.id;
                    productTags.idTags = tagid;
                    _iProductTagsRepository.Add(productTags);
                }
            }
        }

        Product IProductService.Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public string GetOrd(int idCate)
        {
            return _productRepository.GetOrds(idCate);
        }
    }
}
