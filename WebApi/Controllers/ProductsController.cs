using AutoMapper;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public ProductsController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        //public IQueryable<CategoryViewModel> Get(string category = null)
        //{
        //    IEnumerable<CategoryViewModel> viewModelGadgets;
        //    IEnumerable<Category> categories;

        //    categories = categoryService.GetCategories(category).ToList();

        //    viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

        //    return viewModelGadgets.AsQueryable();
        //}

        public IQueryable<ProductViewModel> Get()
        {
            IEnumerable<ProductViewModel> productViewModels;
            IEnumerable<Product> products;

            products = productService.GetProducts().ToList();

            productViewModels = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return productViewModels.AsQueryable();

            //var settings = new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //};

            //var str = Newtonsoft.Json.JsonConvert.SerializeObject(productViewModels, settings);

           // return str;
            //return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(productViewModels, settings));

        }



        public string Get(string category, string productName)
        {
            IEnumerable<ProductViewModel> viewModelproducts;
            IEnumerable<Product> products;

            products = productService.GetCategoryProducts(category, productName);

            viewModelproducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            return string.Empty;
        }

        [HttpPost]
        public string Create(ProductFormViewModel newProduct)
        {
            if (newProduct != null && newProduct.File != null)
            {
                var product = Mapper.Map<ProductFormViewModel, Product>(newProduct);
                productService.CreateProduct(product);

                string gadgetPicture = System.IO.Path.GetFileName(newProduct.File.FileName);
                string path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Content/images/"), gadgetPicture);
                newProduct.File.SaveAs(path);

                productService.SaveGadget();
            }

            var category = categoryService.GetCategory(newProduct.ProductCategory);
            return string.Empty;
            //return RedirectToAction("Index", new { category = category.Name });
        }
    }
}
