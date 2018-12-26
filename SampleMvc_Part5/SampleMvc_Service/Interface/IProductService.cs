﻿using SampleMvc_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMvc_Service.Interface
{
    public interface IProductService
    {
        IResult Create(Product instance);

        IResult Update(Product instance);

        IResult Delete(int productID);

        bool IsExist(int productID);

        Product GetByID(int productID);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetByCategoryID(int categoryID);
    }
}
