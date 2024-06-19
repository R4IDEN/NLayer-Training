using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            /*
             * bu bir eager loading örneğidir.
             * Product'ları çektiğimiz an category'leri de çekersek Eager Loading'tir.
             * Fakat product'ları direkt çekip kategori'yi ihtiyaç anında çekersek bu Lazy Loading'tir. */

            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
