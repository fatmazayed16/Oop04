using Oop04.Delivery;
using Oop04.Interfaces;
namespace Oop04.Shipments;

internal class InternationalShipment : Shipment, ITrackable, IInsurable
{
    #region Fields
    private string destinationCountry;
    private decimal customsFee;

    #endregion

    #region Constructor
    public InternationalShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress destination, string destinationCountry, decimal customsFee)
        : base(description, weight, deliveryFee, trackingCode, destination)
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
    }
    #endregion

    #region Properties
    public string DestinationCountry
    {
        get
        {
            return destinationCountry;
        }
        set
        {
            destinationCountry = string.IsNullOrWhiteSpace(value) ? destinationCountry : value;
        }
    }
    public decimal CustomsFee
    {
        get{ return customsFee;}
        set
        {
            customsFee = value >= 0 ? value : customsFee;
        }
    }
    public override decimal EstimatedCost
    {
        get
        {
            return DeliveryFee + (Weight * 5m) + CustomsFee;
        }
    }

    #endregion

    #region Methods
    public override void PrintShipment()
    {
        Console.WriteLine($"International Shipment - Tracking Code: {TrackingCode}, " +
            $"Description: {Description}, " +
            $"Weight: {Weight} kg, " +
            $"Delivery Fee: {DeliveryFee:C}, " +
            $"Customs Fee: {CustomsFee:C}, " +
            $"Estimated Cost: {EstimatedCost:C}, " +
            $"Destination: {Destination.GetFullAddress()}, " +
            $"Destination Country: {DestinationCountry}");
    }
    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Deliverd";
    }
    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.12m;
    }
    public virtual string GenerateCustomsReport()
    {
        return $"Customs Report for Shipment {TrackingCode}: " +
            $"Destination Country: {DestinationCountry}, " +
            $"Customs Fee: {CustomsFee:C}";
    }
    #endregion
}
