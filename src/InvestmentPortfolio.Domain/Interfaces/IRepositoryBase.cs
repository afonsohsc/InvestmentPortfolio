namespace InvestmentPortfolio.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void DeleteById(int id);
        void Delete(TEntity entity);
        void Dispose();
    }
}
