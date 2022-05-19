using Shop.Domain.Entities;


namespace MarketPlace.DataLayer.Repository
{
    public interface IGenericRepository<TEntity> : IAsyncDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQuery();
        Task AddEntity(TEntity entity);
        Task<TEntity> GetEntityById(string entityId);
        void EditEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        Task DeleteEntity(string entityId);
        void DeletePermanent(TEntity entity);
        Task DeletePermanent(string entityId);
        Task SaveChanges();
    }
}