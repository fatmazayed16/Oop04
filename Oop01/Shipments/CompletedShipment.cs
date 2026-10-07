using Oop04.Delivery;

namespace Oop04.Shipments;

internal sealed class CompletedShipment : Shipment
{
    #region Constructor
    public CompletedShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress destination)
        : base(description, weight, deliveryFee, trackingCode, destination)
    { }
    #endregion

    #region Properties
    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5m);
        }
    }
    #endregion

    #region Method
    public override void PrintShipment()
    {
        Console.WriteLine($"Completed Shipment - Tracking Code: {TrackingCode}, " +
            $"Description: {Description}, " +
            $"Weight: {Weight}, " +
            $"Delivery Fee: {DeliveryFee:C}, " +
            $"Estimated Cost: {EstimatedCost:C}, " +
            $"Destination: {Destination.GetFullAddress()}");

    }
    #endregion
}
