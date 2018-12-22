﻿using SampleMvc_Models;
using SampleMvc_Models.Interface;
using SampleMvc_Models.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SampleMvc_Web.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public IEnumerable<Category> Categories
        {
            get
            {
                return _categoryRepository.GetAll();
            }
        }

        public ProductController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productRepository.GetAll().ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var product = _productRepository.GetByID(id.Value);
                return View(product);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid && product != null)
            {
                _productRepository.Create(product);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var product = _productRepository.GetByID(id.Value);
                ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", product.CategoryID);
                return View(product);
            }
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid && product != null)
            {
                _productRepository.Update(product);
                ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", product.CategoryID);
                return View(product);
            }
            else
            {
                return RedirectToAction("index");
            }

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var product = _productRepository.GetByID(id.Value);
                return View(product);
            }
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = _productRepository.GetByID(id);
                _productRepository.Delete(product);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }


    }
}
