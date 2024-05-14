using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();
        // ProductRepository.Where(x=>x.id>5)
        // IQeryable'ı tek başına kullanıp ToList demememizin sebebi ToList dediğimizde veri tabanına gidip veriyi alıp dönmesi.
        
        //<T> IQueryable olsun ve <T> ile de herhangi bir class, entity vs verilebilsin.
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);

        //IEnumerable interface’i bize bir collection üzerinde iterasyon yapabilmemizi sağlayan enumerator’ı sağlar.
        Task AddRAngeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);


    }
}
