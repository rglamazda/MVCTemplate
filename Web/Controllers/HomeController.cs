using AutoMapper;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService gadgetService;

        public HomeController(ICategoryService categoryService, IProductService gadgetService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();

            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View(viewModelGadgets);
        }


        public ActionResult Filter(string category, string productName)
        {
            IEnumerable<ProductViewModel> viewModelproductss;
            IEnumerable<Product> products;

            products = gadgetService.GetCategoryProducts(category, productName);

            viewModelproductss = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return View(viewModelproductss);
        }

        [HttpPost]
        public ActionResult Create(ProductFormViewModel newProduct)
        {
            if (newProduct != null && newProduct.File != null)
            {
                var product = Mapper.Map<ProductFormViewModel, Product>(newProduct);
                gadgetService.CreateProduct(product);

                string gadgetPicture = System.IO.Path.GetFileName(newProduct.File.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/images/"), gadgetPicture);
                newProduct.File.SaveAs(path);

                gadgetService.SaveGadget();
            }

            var category = categoryService.GetCategory(newProduct.ProductCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }
    }
}