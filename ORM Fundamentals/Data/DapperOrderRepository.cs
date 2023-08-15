using ORM_Fundamentals.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Fundamentals.Data
{
    public class DapperOrderRepository
    {
        private readonly DapperDbContext _context;

        public DapperOrderRepository(DapperDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("INSERT INTO Orders (ProductId, Status, CreatedDate, UpdatedDate) VALUES (@ProductId, @Status, @CreatedDate, @UpdatedDate)", order);
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("UPDATE Orders SET ProductId = @ProductId, Status = @Status, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate WHERE Id = @Id", order);
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("DELETE FROM Orders WHERE Id = @OrderId", new { OrderId = orderId });
            }
        }

        public List<Order> GetOrdersByFilter(DateTime startDate, DateTime endDate, string status, int productId)
        {
            using (var connection = _context.Connection)
            {
                return connection.Query<Order>("SELECT * FROM Orders WHERE CreatedDate >= @StartDate AND CreatedDate <= @EndDate AND Status = @Status AND ProductId = @ProductId",
                    new { StartDate = startDate, EndDate = endDate, Status = status, ProductId = productId }).ToList();
            }
        }

        public void BulkDeleteOrdersByFilter(DateTime startDate, DateTime endDate, string status, int productId)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("DELETE FROM Orders WHERE CreatedDate >= @StartDate AND CreatedDate <= @EndDate AND Status = @Status AND ProductId = @ProductId",
                    new { StartDate = startDate, EndDate = endDate, Status = status, ProductId = productId });
            }
        }
    }
}
