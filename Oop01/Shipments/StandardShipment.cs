using Oop04.Delivery;
using Oop04.Interfaces;
namespace Oop04.Shipments;

public class StandardShipment : Shipment, IInsurable, ITrackable
{
    public StandardShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress destination)
        : base(description, weight, deliveryFee, trackingCode, destination)
    {
    }
    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5m);
        }
    }
    public override void PrintShipment()
    {
        Console.WriteLine($"Standard Shipment - Tracking Code: {TrackingCode}," +
            $" Description: {Description}," +
            $" Weight: {Weight} kg," +
            $" Delivery Fee: {DeliveryFee:C}," +
            $" Estimated Cost: {EstimatedCost:C}," +
            $" Destination: {Destination.GetFullAddress()}");
    }
    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Ready";
    }
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m;
    }
}
