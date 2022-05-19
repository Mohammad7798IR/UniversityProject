using Shop.Data.Context;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public partial class OrderRepository : IOrderRepository
    {
        private readonly MollaShopDBContext _context;

        public OrderRepository(MollaShopDBContext context)
        {
            _context = context;
        }

    }
    public partial class OrderRepository
    {

    }
}
