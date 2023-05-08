using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCore.src
{
    public class OrderRepository
    {
        private static int ordId;

        public static void CreateNewOrder(int ordId)
        {
            using (var context = new OrderContext())
            {
                var newOrder = new Order
                {
                    ord_id = ordId,
                    ord_datetime = DateTime.Now,
                    ord_an = 1
                };

                context.Orders.Add(newOrder);
                context.SaveChanges();

                Console.WriteLine("Створено нове Замовлення:");

                var order = context.Orders
                    .FirstOrDefault(o => o.ord_id == newOrder.ord_id);

                Console.WriteLine($" id Замовлення: {order.ord_id}");
                Console.WriteLine($" дата замовлення: {order.ord_datetime}");
                Console.WriteLine($"ID аналізу: {order.ord_an}");
            }
        }
        public static async void UpdateOrder(int ordId)
        {
            using (var context = new OrderContext())
            {

                var order = await context.Orders.FindAsync(ordId);
                if (order == null)
                {
                    Console.WriteLine($"Замовлення з id: {ordId} не знайдено.");
                    return;
                }


                order.ord_datetime = DateTime.Now;
                context.Orders.Update(order);
                await context.SaveChangesAsync();
                Console.WriteLine($"Замовлення з id: {ordId} оновлено.");
            }
        }

        public static async  void DeleteOrder(int ordid)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.FirstOrDefault(o => o.ord_id == ordid);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    Console.WriteLine("Замовлення з id: {0} видалено.", ordid);
                }
                else
                {
                    Console.WriteLine("Замовлення з цим id: {0} не існує.", ordid);
                }
            }
        }

    }
}