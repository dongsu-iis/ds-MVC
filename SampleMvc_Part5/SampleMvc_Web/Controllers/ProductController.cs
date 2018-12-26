using SampleMvc_Models;
using SampleMvc_Service;
using SampleMvc_Service.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SampleMvc_Web.Controllers
{
    public class ProductController : Controller
    {

        private IProductService _productService;
        private ICategoryService _categoryService;

        public IEnumerable<Category> Categories
        {
            get
            {
                return _categoryService.GetAll();
            }
        }

        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productService.GetAll().ToList();
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
                var product = _productService.GetByID(id.Value);
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
                _productService.Create(product);
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
                var product = _productService.GetByID(id.Value);
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
                _productService.Update(product);
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
                var product = _productService.GetByID(id.Value);
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
                _productService.Delete(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }


    }
}
