using InvestmentPortfolio.Domain.Interfaces;
using InvestmentPortfolio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPortfolio.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        private readonly InvestmentPortfolioContext _context;
        public RepositoryBase(InvestmentPortfolioContext context) => _context = context;

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().FirstOrDefault(t => t.Id == id);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
