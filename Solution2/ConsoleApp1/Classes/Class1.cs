using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public class Product
    {
        public int Id { get; set; }
    }

    public class PaymentService
    {
        private ProductService _productService;
        private OrderService _orderService;

        public PaymentService(IPaymentFactory paymentFactory)
        {
            _productService = paymentFactory.GetProductService();
            _orderService = paymentFactory.GetOrderService();
        }

        public void Pay(int productId)
        {
            _productService.GetById(productId);
            _orderService.CreateOrder(productId);
        }
    }

    //Product Service
    public abstract class ProductService
    {
        public abstract Product GetById(int id);
    }
    public class LiveProductService : ProductService
    {
        public override Product GetById(int id)
        {
            List<Product> liveProductDatabase = new();
            Console.WriteLine($"Canlı veritabanından : {id} ' li product getirildi.");
            return liveProductDatabase.SingleOrDefault(x => x.Id == id);
        }
    }
    public class DemoProductService : ProductService
    {
        public override Product GetById(int id)
        {
            List<Product> demoProductDatabase = new();
            Console.WriteLine($"Demo veritabanından : {id} ' li product getirildi.");
            return demoProductDatabase.SingleOrDefault(x => x.Id == id);
        }
    }

    //Order Service
    public abstract class OrderService
    {
        public abstract void CreateOrder(int productId);
    }
    public class LiveOrderService : OrderService
    {
        public override void CreateOrder(int productId)
        {
            Console.WriteLine($"Canlı veritabanına :{productId} li ürün için sipariş oluşturuldu.");
        }
    }
    public class DemoOrderService : OrderService
    {
        public override void CreateOrder(int productId)
        {
            Console.WriteLine($"Demo veritabanına :{productId} li ürün için sipariş oluşturuldu.");
        }
    }

    public interface IPaymentFactory
    {
        ProductService GetProductService();
        OrderService GetOrderService();
    }

    public class LivePaymentServiceFactory : IPaymentFactory
    {
        public OrderService GetOrderService()
        {
            return new LiveOrderService();
        }

        public ProductService GetProductService()
        {
            return new LiveProductService();
        }
    }

    public class DemoPaymentServiceFactory : IPaymentFactory
    {
        public OrderService GetOrderService()
        {
            return new DemoOrderService();
        }

        public ProductService GetProductService()
        {
            return new DemoProductService();
        }
    }

}
