using Dapper;
using ORM_Fundamentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Fundamentals.Data
{
    public class DapperProductRepository
    {
        private readonly DapperDbContext _context;

        public DapperProductRepository(DapperDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("INSERT INTO Products (Name, Description, Weight, Height, Width, Length) VALUES (@Name, @Description, @Weight, @Height, @Width, @Length)", product);
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("UPDATE Products SET Name = @Name, Description = @Description, Weight = @Weight, Height = @Height, Width = @Width, Length = @Length WHERE Id = @Id", product);
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var connection = _context.Connection)
            {
                connection.Execute("DELETE FROM Products WHERE Id = @ProductId", new { ProductId = productId });
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var connection = _context.Connection)
            {
                return connection.Query<Product>("SELECT * FROM Products").ToList();
            }
        }
    }
}
