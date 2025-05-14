using AstroTech.BLL.DTOs;
using AstroTech.DAL.Models;
using System.Collections.Generic;

namespace AstroTech.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> FeaturedCategories { get; set; }
        public IEnumerable<ProductDTO> NewProducts { get; set; }  
        public IEnumerable<ProductDTO> TopSelling { get; set; }  
        public IEnumerable<ProductDTO> AllProducts { get; set; }  
    }
}
