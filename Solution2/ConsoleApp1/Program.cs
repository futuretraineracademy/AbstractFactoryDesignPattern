using ConsoleApp1.Classes;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PaymentService paymentService = new PaymentService(new DemoProductService(), new LiveOrderService());
            //paymentService.Pay(1);

            PaymentService paymentService = new PaymentService(new LivePaymentServiceFactory());
            paymentService.Pay(1);
        }
    }
}
