using Oop04.Interfaces;
namespace Oop04.Delivery
{
    internal class DeliveryReport
    {
        public void PrintShipment(ITrackable shipment)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }
        public void PrintInsurance(IInsurable shipment)
        {
            Console.WriteLine($"Insurance Cost: {shipment.CalculateInsurance():C}");
        }
    }
}
