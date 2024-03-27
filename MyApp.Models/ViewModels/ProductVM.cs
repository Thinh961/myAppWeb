using System.Web.Mvc;

namespace MyApp.Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}