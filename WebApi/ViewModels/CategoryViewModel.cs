using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}