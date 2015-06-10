using AutoMapper;
using Model;
using Newtonsoft.Json;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService gadgetService;

        public HomeController(ICategoryService categoryService, IProductService gadgetService)
        {
            this.categoryService = categoryService;
            this.gadgetService = gadgetService;
        }

        // GET: Home
        public string Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories(category).ToList();

            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            
            return JsonConvert.SerializeObject(viewModelGadgets);
        }


        public string Filter(string category, string productName)
        {
            IEnumerable<ProductViewModel> viewModelproductss;
            IEnumerable<Product> products;

            products = gadgetService.GetCategoryProducts(category, productName);

            viewModelproductss = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return JsonConvert.SerializeObject(viewModelproductss);
        }

        [HttpPost]
        public string Create(ProductFormViewModel newProduct)
        {
            if (newProduct != null && newProduct.File != null)
            {
                var product = Mapper.Map<ProductFormViewModel, Product>(newProduct);
                gadgetService.CreateProduct(product);

                string gadgetPicture = System.IO.Path.GetFileName(newProduct.File.FileName);
                string path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/"), gadgetPicture);
                newProduct.File.SaveAs(path);

                gadgetService.SaveGadget();
            }

            var category = categoryService.GetCategory(newProduct.ProductCategory);
            return string.Empty;
            //return RedirectToAction("Index", new { category = category.Name });
        }
    }
}
