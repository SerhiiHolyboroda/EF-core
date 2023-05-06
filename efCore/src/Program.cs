using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efCore.src
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
          //  using (var context = new OrderContext())
         //   {
          //      DateTime startDate = DateTime.Now.AddYears(-1);
          //      var orders = context.Orders.Where(o => o.ord_datetime >= startDate).ToList();

          //      foreach (var order in orders)
          //      {
         //           Console.WriteLine("Order ID: " + order.ord_id);
          //          Console.WriteLine("Order Date: " + order.ord_datetime);
          //          Console.WriteLine("Analysis ID: " + order.ord_an);
          //          Console.WriteLine("---------------------------");
          //      }
          //  }



            int ordId = new Random().Next(1, 1000000);
            OrderRepository.CreateNewOrder(ordId);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            OrderRepository.UpdateOrder(ordId);
            await Task.Delay(2000);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            OrderRepository.DeleteOrder(ordId);
            await Task.Delay(3000);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
    }
 