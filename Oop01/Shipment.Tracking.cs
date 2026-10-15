namespace Oop04;

public abstract partial class Shipment
{
    private string trackingStatus = "Ready";

    public string TrackingStatus
    {
        get { return trackingStatus; }
        set { trackingStatus = value; }
    }

    public virtual void UpdateTrackingStatus(string NewStatus)
    {
        if (!string.IsNullOrEmpty(NewStatus))
        {
            TrackingStatus = NewStatus;
        }
    }

    public virtual string GetTrackingStatus()
    {
        return($"Tracking status for {TrackingCode} changed to: {TrackingStatus}.");
    }
}
