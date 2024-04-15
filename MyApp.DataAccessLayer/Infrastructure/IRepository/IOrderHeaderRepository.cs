using MyApp.Models;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int Id, string orderStatus, string? paymentStatus = null);

    }
}