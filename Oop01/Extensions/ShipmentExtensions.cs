namespace Oop04.Extensions;

internal static class ShipmentExtensions
{
    public static string GetSummary(this Shipment shipment)
    {
        string shipmentType = shipment.GetType().Name.Replace("Shipment", "");
        return $"{ shipment.TrackingCode} | { shipmentType} | { shipment.Weight} kg | { shipment.TrackingStatus}";
    }

    public static bool IsDelivered(this Shipment shipment)
    {
        return shipment.TrackingStatus == "Delivered";
    }
}
