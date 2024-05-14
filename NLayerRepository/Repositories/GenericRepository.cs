using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using System.Linq.Expressions;

namespace NLayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRAngeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

         /*
         * AsQueryable'dan sonra to list veya Any demedik. Bunun sebebi eğer ki listeleme veya 
         * başka bir işlem yapmak istiyorsak onu yapıp ondan sonra data'yı çekmek db'den.
         * AsNoTracking demezsek bu dataları memory'e alıp onları track etmek için performans gücünün bir kısmını buna aktaracak.
         */
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

         /*
         * Remove metodunun async hali yok, biz burdan remove dediğimizde state'i deleted 
         * olarak flagleniyor. SaveChanges komutu çalıştığında veritabanından siliniyor.
         */
        public void Remove(T entity)
        {
            //_context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            //_context.Entry(entities).State = EntityState.Deleted;
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
