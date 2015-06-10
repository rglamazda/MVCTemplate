using Data.Infrastructure;
using Data.Repositories;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetCategoryProducts(string categoryName, string productName = null);
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void SaveGadget();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository gadgetsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.productsRepository = gadgetsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<Product> GetProducts()
        {
            var gadgets = productsRepository.GetAll();
            return gadgets;
        }

        public IEnumerable<Product> GetCategoryProducts(string categoryName, string gadgetName = null)
        {
            var category = categoryRepository.GetCategoryByName(categoryName);
            return category.Products.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Product GetProduct(int id)
        {
            var gadget = productsRepository.GetById(id);
            return gadget;
        }

        public void CreateProduct(Product product)
        {
            productsRepository.Add(product);
        }

        public void SaveGadget()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
