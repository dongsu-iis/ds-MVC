﻿using SampleMvc_Models;
using SampleMvc_Service.Interface;
using SampleMvc_Service;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SampleMvc_Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }


        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll().ToList();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var category = _categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid && category != null)
            {
                _categoryService.Create(category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var category = _categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid && category != null)
            {
                _categoryService.Update(category);
                return View(category);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }
            else
            {
                var category = _categoryService.GetByID(id.Value);
                return View(category);
            }
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _categoryService.Delete(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }

    }
}
