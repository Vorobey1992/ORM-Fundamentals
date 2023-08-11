using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ORM_Fundamentals.Models;

namespace ORM_Fundamentals.Data
{
    public class DataAccess
    {
        private readonly AppDbContext _context;

        public DataAccess(AppDbContext context)
        {
            _context = context;
        }

        // CRUD operations for Product
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        // CRUD operations for Order
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

        public List<Order> GetOrdersByFilter(DateTime startDate, DateTime endDate, string status, int productId)
        {
            return _context.Orders
                .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate && o.Status == status && o.ProductId == productId)
                .ToList();
        }

        public void BulkDeleteOrdersByFilter(DateTime startDate, DateTime endDate, string status, int productId)
        {
            var ordersToDelete = _context.Orders
                .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate && o.Status == status && o.ProductId == productId)
                .ToList();

            _context.Orders.RemoveRange(ordersToDelete);
            _context.SaveChanges();
        }
    }
}
