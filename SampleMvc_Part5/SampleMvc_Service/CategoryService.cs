using SampleMvc_Models;
using SampleMvc_Models.Interface;
using SampleMvc_Models.Repository;
using SampleMvc_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SampleMvc_Service
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repository = new GenericRepository<Category>();

        public IResult Create(Category instance)
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

        public IResult Update(Category instance)
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

        public IResult Delete(int categoryID)
        {
            IResult result = new Result(false);

            if (!IsExist(categoryID))
            {
                result.Message = "データが存在しません";
            }

            try
            {
                var instance = GetByID(categoryID);
                _repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public bool IsExist(int categoryID)
        {
            return _repository.GetAll().Any(x => x.CategoryID == categoryID);
        }

        public Category GetByID(int categoryID)
        {
            return _repository.Get(x => x.CategoryID == categoryID);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }

    }
}
