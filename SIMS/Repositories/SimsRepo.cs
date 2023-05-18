using Microsoft.EntityFrameworkCore;
using SIMS.Context;

namespace SIMS.Repositories
{
    public class SimsRepo<T> : ISimsRepo<T> where T : class
    {
        private readonly SimsDbContext _context;
        private readonly DbSet<T> _dbSet;   
        public SimsRepo(SimsDbContext context)
        {
            _context = context;
            _dbSet =_context.Set<T>();
        }
        public void Add(T value)
        {
            _context.Add(value);
            _context.SaveChanges();
        }

        public int Delete(Guid id)
        {

            var dbValue= GetById(id);
            if (dbValue != null)
            {
                _dbSet.Remove(dbValue);
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(Guid id)
        {
            var dbData = _dbSet.Find(id);
            return dbData;
        }

        public bool Update(T value, Guid id)
        {
            var valueInDb = GetById(id);
            try
            {
               
                if (valueInDb != null)
                {
                    
                    _context.Update(value);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {

                return false;
            }
        }

        public bool Update(T value)
        {
            try
            {
                    _context.Update(value);
                    _context.SaveChanges();
                
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                
                return false;
            }
        }
    }
}
