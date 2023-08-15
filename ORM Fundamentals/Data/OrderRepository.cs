using Microsoft.EntityFrameworkCore;
using ORM_Fundamentals.Models;

namespace ORM_Fundamentals.Data
{
    public class OrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public List<Order> GetOrdersByFilter(DateTime startDate, DateTime endDate, OrderStatus status, int productId)
        {
            string statusString = status.ToString(); // Преобразование OrderStatus в строку
            return _context.Orders
                .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate && o.Status == statusString && o.ProductId == productId)
                .ToList();
        }

        public void BulkDeleteOrdersByFilter(DateTime startDate, DateTime endDate, OrderStatus status, int productId)
        {
            string statusString = status.ToString(); // Преобразование OrderStatus в строку

            var ordersToDelete = _context.Orders
                .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate && o.Status == statusString && o.ProductId == productId)
                .ToList();

            _context.Orders.RemoveRange(ordersToDelete);
            _context.SaveChanges();
        }
    }
}
