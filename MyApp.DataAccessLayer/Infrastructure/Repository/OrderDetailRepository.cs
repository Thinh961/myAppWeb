using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            //var categoryDB = _context.Categories.FirstOrDefault(x => x.Id == orderDetail.Id);
            //if (categoryDB != null)
            //{
            //    categoryDB.Name = category.Name;
            //    categoryDB.DisplayOrder = category.DisplayOrder;
            //}
        }
    }
}