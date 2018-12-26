using SampleMvc_Models;
using SampleMvc_Models.Interface;
using SampleMvc_Models.Repository;
using SampleMvc_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleMvc_Service
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _repository = new GenericRepository<Product>();

        public IResult Create(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);

            try
            {
                _repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public IResult Update(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                _repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int productID)
        {
            IResult result = new Result(false);

            if (!IsExist(productID))
            {
                result.Message = "データが存在しません";
            }

            try
            {
                var instance = GetByID(productID);
                _repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public bool IsExist(int productID)
        {
            return _repository.GetAll().Any(x => x.ProductID == productID);
        }

        public Product GetByID(int productID)
        {
            return _repository.Get(x => x.ProductID == productID);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Product> GetByCategoryID(int categoryID)
        {
            return _repository.GetAll().Where(x => x.CategoryID == categoryID);
        }

    }
}
