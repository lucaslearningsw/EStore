

namespace EStore.Catalog.Domain;
public interface IStockService : IDisposable
{
    Task<bool> DebitStock(Guid productId, int qty);
    Task<bool> ReplenishmentStock(Guid productId, int qty);
}