using System;
using System.Globalization;
using OrderCollection.Entities.Enums;
using OrderCollection.Entities;

namespace OrderCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data");
            Console.Write("Name: ");
            var clientName = Console.ReadLine();
            Console.Write("Email: ");
            var clientEmail = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime dateTime = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            
            Console.WriteLine("Enter order data");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());


            Client client = new Client(clientName, clientEmail, dateTime);
            Order order = new Order(DateTime.Now, orderStatus, client);
            Console.Write("How many items to this order? ");
            var n = int.Parse(Console.ReadLine());
            for(var i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " item data");
                Console.Write("Product name: ");
                var nameProd = Console.ReadLine();
                Console.Write("Product price: ");
                var priceProd = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                var qtProd = int.Parse(Console.ReadLine());

                Product product = new Product(nameProd, priceProd);
                OrderItem orderItem = new OrderItem(qtProd, priceProd, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("Order Summary");
            Console.WriteLine("Order moment: " + DateTime.Now);
            Console.WriteLine("Order status: " + orderStatus);
            Console.WriteLine("Client: " + client.Name + " " + client.BirthDate + " - " + client.Email);

            Console.WriteLine();
            Console.WriteLine("Order items");
            Console.WriteLine(order);
            Console.WriteLine();


        }
    }
}
