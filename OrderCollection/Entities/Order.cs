using System;
using OrderCollection.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace OrderCollection.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem orderItem in Items)
            {
                sum += orderItem.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(OrderItem item in Items)
            {
                stringBuilder.Append(item.ToString());
            }
            stringBuilder.AppendLine("Total price: $" + Total().ToString("F2"));

            return stringBuilder.ToString();
        }
    }
}
