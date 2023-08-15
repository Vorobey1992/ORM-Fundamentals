using ORM_Fundamentals.Data;
using ORM_Fundamentals.Models;

using (var context = new AppDbContext())
{
    var productRepository = new ProductRepository(context);
    var orderRepository = new OrderRepository(context);

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

    productRepository.CreateProduct(newProduct);

    var newOrder = new Order
    {
        ProductId = newProduct.Id,
        Status = OrderStatus.NotStarted,
        CreatedDate = DateTime.Now,
        UpdatedDate = DateTime.Now
    };

    orderRepository.CreateOrder(newOrder);

    var orders = orderRepository.GetOrdersByFilter(DateTime.Today.AddDays(-7), DateTime.Today, OrderStatus.NotStarted, newProduct.Id);
    foreach (var order in orders)
    {
        Console.WriteLine($"Order ID: {order.Id}, Status: {order.Status}");
    }

    orderRepository.BulkDeleteOrdersByFilter(DateTime.Today.AddDays(-7), DateTime.Today, OrderStatus.NotStarted, newProduct.Id);
}

//
/*
 * using (var context = new AppDbContext())
            {
                var productRepository = new DapperProductRepository(context);
                var orderRepository = new DapperOrderRepository(context);

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

                productRepository.CreateProduct(newProduct);

                var newOrder = new Order
                {
                    ProductId = newProduct.Id,
                    Status = OrderStatus.NotStarted,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                orderRepository.CreateOrder(newOrder);

                var orders = orderRepository.GetOrdersByFilter(DateTime.Today.AddDays(-7), DateTime.Today, OrderStatus.NotStarted, newProduct.Id);
                foreach (var order in orders)
                {
                    Console.WriteLine($"Order ID: {order.Id}, Status: {order.Status}");
                }

                orderRepository.BulkDeleteOrdersByFilter(DateTime.Today.AddDays(-7), DateTime.Today, OrderStatus.NotStarted, newProduct.Id);
            }
*/