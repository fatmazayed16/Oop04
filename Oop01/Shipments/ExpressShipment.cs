using Oop04.Interfaces;
using Oop04.Delivery;

namespace Oop04.Shipments;

internal class ExpressShipment : Shipment, ITrackable, IInsurable
{
    #region Fields

    private decimal extraFee;

    #endregion

    #region Constructor

    public ExpressShipment(
        string description,
        decimal weight,
        decimal deliveryFee,
        string trackingCode,
        DeliveryAddress destination,
        decimal extraFee)
        : base(description, weight, deliveryFee, trackingCode, destination)
    {
        ExtraFee = extraFee;
    }

    #endregion

    #region Properties

    public decimal ExtraFee
    {
        get
        {
            return extraFee;
        }
        set
        {
            extraFee = value >= 0 ? value : extraFee;
        }
    }

    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5m) + ExtraFee;
        }
    }

    #endregion

    #region Methods

    public override void PrintShipment()
    {
        Console.WriteLine(
            $"Express Shipment - Tracking Code: {TrackingCode}, " +
            $"Description: {Description}, " +
            $"Weight: {Weight} kg, " +
            $"Delivery Fee: {DeliveryFee:C}, " +
            $"Extra Fee: {ExtraFee:C}, " +
            $"Estimated Cost: {EstimatedCost:C}, " +
            $"Destination: {Destination.GetFullAddress()}");
    }

    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Out for Delivery.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.08m;
    }

    #endregion
}