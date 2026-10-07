using Oop04.Interfaces;
namespace Oop04.Delivery;

internal class DeliveryCenter
{
    #region Fields
    private readonly Shipment[] shipments = new Shipment[20];
    #endregion

    #region Properties
    public string CenterName { get; set; }
    public Driver? Driver { get; set; }
    #endregion

    #region Constructor
    public DeliveryCenter(string centerName)
    {
        CenterName = centerName;
    }
    #endregion

    #region Indexers

    #region Integer Indexer
    // Integer indexer: gets or replaces a shipment by its position.
    public Shipment this[int index]
    {
        get => index >= 0 && index < shipments.Length ? shipments[index] : default;
        set
        {
            if (index >= 0 && index < shipments.Length)
            {
                shipments[index] = value;
            }
        }
    }
    #endregion
    #region String Indexer
    // String indexer: finds the first shipment with the given tracking code
    public Shipment this[string trackingCode]
    {
        get
        {
            foreach (Shipment shipment in shipments)
            {
                if (shipment != null && shipment.TrackingCode == trackingCode)
                {
                    return shipment;
                }
            }
            return default;
        }
    }
    #endregion
    #endregion

    #region Shipment Management
    // Adds a shipment to the first available position
    public bool AddShipment(Shipment shipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)
            {
                shipments[i] = shipment;
                return true;
            }
        }
        return false;
    }
    // Removes a shipment using its tracking code
    public bool RemoveShipment(string trackingCode)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
            {
                shipments[i] = null;
                return true;
            }
        }
        return false;
    }
    // Prints all shipments in the center
    public void PrintAllShipments()
    {
        foreach (Shipment shipment in shipments)
        {
            if (shipment != null)
            {
                shipment.PrintShipment();
            }
        }
    }
    #endregion

    #region Interface Polymorphism 
    // Prints the tracking status through the ITrackable interface>
    public void PrintShipment(ITrackable shipment)
    {
        Console.WriteLine(shipment.GetTrackingStatus());
    }
    // Prints the insurance cost through the IInsurable interface.
    public void PrintInsurance(IInsurable shipment)
    {
        Console.WriteLine($"Insurance Cost for Shipment {shipment.CalculateInsurance():C}");
    }
    // Prints the tracking statuses of all trackable shipments in the center>
    public void PrintTrackingStatuses()
    {
        foreach (Shipment shipment in shipments)
        {
            if (shipment is ITrackable trackable)
            {
                Console.WriteLine(trackable.GetTrackingStatus());
            }
        }
    }
    #endregion

}
