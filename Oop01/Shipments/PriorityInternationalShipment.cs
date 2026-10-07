using Oop04.Delivery;

namespace Oop04.Shipments;

internal class PriorityInternationalShipment : InternationalShipment
{
    #region Constructor
    public PriorityInternationalShipment(string description, decimal weight, decimal deliveryFee, 
        string trackingCode, DeliveryAddress destination, string destinationCountry, decimal customsFee)
        : base(description, weight, deliveryFee, trackingCode, destination, destinationCountry, customsFee)
    {
    }
    #endregion

    #region Methods
    public sealed override string GenerateCustomsReport()
    {
        return $"Priority Customs Report for Shipment {TrackingCode}: " +
               $"Destination Country: {DestinationCountry}, " +
               $"Customs Fee: {CustomsFee:C}, " +
               $"Priority Handling: Required";
    }
    #endregion
}
