using ORM_Fundamentals.Data;
using ORM_Fundamentals.Models;

using (var context = new AppDbContext())
{
    var dataAccess = new DataAccess(context);

    // Пример использования методов
    var newProduct = new Product
    {
        Name = "Sample Product",
        Description = "A sample product description",
        Weight = 1.5m,
        Height = 10,
        Width = 5,
        Length = 8
    };

    dataAccess.CreateProduct(newProduct);

    var newOrder = new Order
    {
        ProductId = newProduct.Id,
        Status = "NotStarted",
        CreatedDate = DateTime.Now,
        UpdatedDate = DateTime.Now
    };

    dataAccess.CreateOrder(newOrder);

    var orders = dataAccess.GetOrdersByFilter(DateTime.Today.AddDays(-7), DateTime.Today, "NotStarted", newProduct.Id);
    foreach (var order in orders)
    {
        Console.WriteLine($"Order ID: {order.Id}, Status: {order.Status}");
    }

    dataAccess.BulkDeleteOrdersByFilter(DateTime.Today.AddDays(-7), DateTime.Today, "NotStarted", newProduct.Id);
}