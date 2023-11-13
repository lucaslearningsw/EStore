

namespace EStore.Catalog.Domain;
public interface IStockService : IDisposable
{
    Task<bool> StockDebit(Guid productId, int qty);
    Task<bool> StockReplenishment(Guid productId, int qty);
}