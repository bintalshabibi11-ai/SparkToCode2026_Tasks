using System;
using System.Linq;
using ECommerceApp.Models;
namespace ECommerceApp
{
    internal class Program
    {
        static AppDbContext context = new AppDbContext();

        static int loggedInUserId = 0;

        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                Console.WriteLine("\n===== E-Commerce Console App =====");
                Console.WriteLine(" 1. Register New User");
                Console.WriteLine(" 2. Login");
                Console.WriteLine(" 3. Add New Category");
                Console.WriteLine(" 4. Add New Product");
                Console.WriteLine(" 5. View All Products");
                Console.WriteLine(" 6. Place an Order");
                Console.WriteLine(" 7. View My Orders");
                Console.WriteLine(" 8. View Order Details");
                Console.WriteLine(" 9. Add a Review for an Order");
                Console.WriteLine("10. View All Reviews for a Product");
                Console.WriteLine("11. Logout");
                Console.WriteLine(" 0. Exit");
                Console.Write("Enter your choice: ");

                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;

                    case 2:
                        Login();
                        break;

                    case 3:
                        AddCategory();
                        break;

                    case 4:
                        AddProduct();
                        break;

                    case 5:
                        ViewAllProducts();
                        break;

                    case 6:
                        PlaceOrder();
                        break;

                    case 7:
                        ViewMyOrders();
                        break;

                    case 8:
                        ViewOrderDetails();
                        break;

                    case 9:
                        AddReview();
                        break;

                    case 10:
                        ViewReviewsForProduct();
                        break;

                    case 11:
                        Logout();
                        break;

                    case 0:
                        exitApp = true;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // ===================== FUNCTIONS =====================

        static void RegisterUser()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User user = new User
            {
                Name = name,
                Email = email,
                Password = password
            };

            context.Users.Add(user);
            context.SaveChanges();

            Console.WriteLine("User registered successfully.");
        }

        static void Login()
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User user = context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                loggedInUserId = user.UserId;
                Console.WriteLine($"Welcome, {user.Name}!");
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
        }
        static void AddCategory()
        {
            Console.Write("Enter Category Name: ");
            string categoryName = Console.ReadLine();

            Category category = new Category
            {
                Name = categoryName
            };

            context.Categories.Add(category);
            context.SaveChanges();

            Console.WriteLine("Category added successfully.");
        }

        static void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Category Id: ");
            int categoryId = int.Parse(Console.ReadLine());

            Category category = context.Categories
                .FirstOrDefault(c => c.CategoryId == categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            Product product = new Product
            {
                Name = productName,
                Price = price,
                CategoryId = categoryId
            };

            context.Products.Add(product);
            context.SaveChanges();

            Console.WriteLine("Product added successfully.");
        }

        static void ViewAllProducts()
        {
            var products = context.Products
                .Select(p => new
                {
                    p.ProductId,
                    p.Name,
                    p.Price,
                    CategoryName = p.Category.Name
                })
                .ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"Product Id: {product.ProductId}, " +
                    $"Name: {product.Name}, " +
                    $"Price: {product.Price}, " +
                    $"Category: {product.CategoryName}"
                );
            }
        }
        static void PlaceOrder()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            Order order = new Order
            {
                UserId = loggedInUserId,
                OrderDate = DateTime.Now
            };

            context.Orders.Add(order);
            context.SaveChanges();

            while (true)
            {
                Console.Write("Enter Product Id (0 to finish): ");
                int productId = int.Parse(Console.ReadLine());

                if (productId == 0)
                    break;

                Product product = context.Products.FirstOrDefault(p => p.ProductId == productId);

                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                OrderProduct orderProduct = new OrderProduct
                {
                    OrderId = order.OrderId,
                    ProductId = productId,
                    Quantity = quantity
                };

                context.OrderProducts.Add(orderProduct);
            }

            context.SaveChanges();

            Console.WriteLine("Order placed successfully.");
        }

        static void ViewMyOrders()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            var orders = context.Orders
                .Where(o => o.UserId == loggedInUserId)
                .ToList();

            if (orders.Count == 0)
            {
                Console.WriteLine("You have no orders.");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine(
                    $"Order Id: {order.OrderId}, " +
                    $"Order Date: {order.OrderDate}"
                );
            }
        }

        static void ViewOrderDetails()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            Console.Write("Enter Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders
                .Where(o => o.OrderId == orderId && o.UserId == loggedInUserId)
                .Select(o => new
                {
                    o.OrderId,
                    o.OrderDate,
                    Products = o.OrderProducts.Select(op => new
                    {
                        op.Product.Name,
                        op.Product.Price,
                        op.Quantity
                    }).ToList()
                })
                .FirstOrDefault();

            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Console.WriteLine($"Order Id: {order.OrderId}");
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine("Products:");

            foreach (var product in order.Products)
            {
                Console.WriteLine(
                    $"Name: {product.Name}, " +
                    $"Price: {product.Price}, " +
                    $"Quantity: {product.Quantity}"
                );
            }
        }

        static void AddReview()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            Console.Write("Enter Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            Order order = context.Orders
                .FirstOrDefault(o => o.OrderId == orderId &&
                                     o.UserId == loggedInUserId);

            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Review existingReview = context.Reviews
                .FirstOrDefault(r => r.OrderId == orderId);

            if (existingReview != null)
            {
                Console.WriteLine("This order already has a review.");
                return;
            }

            Console.Write("Enter Rating: ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("Enter Comment: ");
            string comment = Console.ReadLine();

            Review review = new Review
            {
                OrderId = orderId,
                Rating = rating,
                Comment = comment
            };

            context.Reviews.Add(review);
            context.SaveChanges();

            Console.WriteLine("Review added successfully.");
        }

        static void ViewReviewsForProduct()
        {
            Console.Write("Enter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            var reviews = context.OrderProducts
                .Where(op => op.ProductId == productId)
                .Select(op => op.Order.Review)
                .Where(r => r != null)
                .ToList();

            if (reviews.Count == 0)
            {
                Console.WriteLine("No reviews found.");
                return;
            }

            foreach (var review in reviews)
            {
                Console.WriteLine($"Rating: {review.Rating}");
                Console.WriteLine($"Comment: {review.Comment}");
                Console.WriteLine("---------------------------");
            }
        }

        static void Logout()
        {
            loggedInUserId = 0;
            Console.WriteLine("Logged out successfully.");
        }
    }
}
