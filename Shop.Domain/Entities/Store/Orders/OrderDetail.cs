using Shop.Domain.Entities;
using Shop.Domain.Entities.MarketPlaceStore.Products;

namespace MarketPlace.DataLayer.Entities.ProductOrder
{
    public class OrderDetail : BaseEntity
    {
        #region properties

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public int Count { get; set; }


        #endregion

        #region relations

        public Order Order { get; set; }

        public Product Product { get; set; }

        #endregion
    }
}
