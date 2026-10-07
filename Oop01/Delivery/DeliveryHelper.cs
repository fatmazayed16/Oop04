namespace Oop04.Delivery;

internal static class DeliveryHelper
{
    // Prints shipment details using dynamic binding
    public static void PrintShipmentDetails(Shipment shipment)
    {
        shipment.PrintShipment();
    }
}
