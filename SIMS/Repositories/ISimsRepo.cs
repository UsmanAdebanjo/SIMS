namespace SIMS.Repositories
{
    public interface ISimsRepo<T> where T : class
    {
        public void Add(T value);
        public bool Update(T value, Guid id);
        public bool Update(T value);

        public int Delete(Guid id);
      
        public T GetById(Guid id);
        public IEnumerable<T> GetAll();


    }
}
