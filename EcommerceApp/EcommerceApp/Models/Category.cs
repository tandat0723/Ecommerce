using System;

namespace EcommerceApp.Models
{
    public class CategoryVM
    {
        public String CategoryName { get; set; }
    }

    public class Category : CategoryVM
    {
        public Guid CategoryID { get; set; }
    }
}
