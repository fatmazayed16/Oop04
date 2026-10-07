using Oop04.Delivery;

namespace Oop04;

public abstract class Shipment
{
    #region Fields
    private string description; 
    private decimal weight;
    private decimal deliveryFee;
    private string trackingCode;
    #endregion

    #region Constructor
    protected Shipment(string trackingCode)
    {
        Description = "Unknown";
        Weight = 1;
        DeliveryFee = 50;
        TrackingCode = trackingCode;
        Destination = new DeliveryAddress("Unknown", "Unknown",0);
    }

    protected Shipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress destination) 
    {
        Description = description;
        Weight = weight;
        DeliveryFee = deliveryFee;
        TrackingCode = trackingCode;
        Destination = destination;
    }
    #endregion

    #region Properties
    public DeliveryAddress Destination { get; set; }
    public string Description
    {
        get { return description;}
        set
        {
            description = string.IsNullOrWhiteSpace(value) ? description : value; 
        }

    }
    public decimal Weight 
    {
        get{ return weight;}
        set 
        {
            weight = value > 0 ? value : weight;
        }
    }
    public decimal DeliveryFee
    {
        get{ return deliveryFee; }
        private set
        {
            deliveryFee = value > 0 ? value : deliveryFee  ;
        }
    }
    public string TrackingCode
    {
        get{ return trackingCode; }
        private set
        {
            trackingCode = string.IsNullOrWhiteSpace(value) ? trackingCode : value;
        }
    }
    public abstract decimal EstimatedCost { get; }
    // Abstract cuz every derived shipment calculates its own cost
    #endregion

    #region Methods
    public void UpdateDeliveryFee(decimal newFee)
    {
        // Update only if the new fee is valid
        DeliveryFee = newFee > 0 ? newFee : DeliveryFee;
    }

    // Method Overloading - updates weight directly
    public void UpdateWeight(decimal newWeight)
    {
        Weight = newWeight > 0 ? newWeight : Weight;
    }
    // Method Overloading - updates weight after adding packing weight
    public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
    {
        if (newWeight > 0 && extraPackingWeight >= 0)
        {
            Weight = newWeight + extraPackingWeight;
        }
    }
    public abstract void PrintShipment();

    #endregion
}
