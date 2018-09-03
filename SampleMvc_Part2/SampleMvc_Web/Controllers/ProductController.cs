using SampleMvc_Web.Models;
using SampleMvc_Web.Models.Interface;
using SampleMvc_Web.Models.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace SampleMvc_Web.Controllers
{
    public class ProductController : Controller
    {

        private IRepository<Product> productRepository;
        private IRepository<Category> categoryRepository;

        public IEnumerable<Category> Categories => categoryRepository.GetAll();

        public ProductController()
        {
            productRepository = new GenericRepository<Product>();
            categoryRepository = new GenericRepository<Category>();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = productRepository.GetAll().ToList();
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
                var product = productRepository.Get(x => x.ProductID == id.Value);
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
                productRepository.Create(product);
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
                var product = productRepository.Get(x => x.ProductID == id.Value);
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
                productRepository.Update(product);
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
                var product = productRepository.Get(x => x.ProductID == id.Value);
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
                var product = productRepository.Get(x => x.ProductID == id);
                productRepository.Delete(product);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id });
            }

            return RedirectToAction("Index");
        }


    }
}
