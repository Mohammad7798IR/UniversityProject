using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.MarketPlaceStore.Products
{
    public partial class Category : BaseEntity
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "فعال / غیر فعال")]
        public bool IsActive { get; set; }

        public string? ParentId { get; set; }
    }

    #region relations 

    public partial class Category
    {
        public ICollection<ProductCategory> productCategories { get; set; } = new HashSet<ProductCategory>();

        public Category? Parent { get; set; }

        //public ICollection<Category> subCategories { get; set; } = new HashSet<Category>();
    }

    #endregion
}
