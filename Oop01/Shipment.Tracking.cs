namespace Oop04;

public abstract partial class Shipment
{
    #region Field
    private string trackingStatus = "Ready";
    #endregion

    #region properties
    public string TrackingStatus
    {
        get { return trackingStatus; }
        set { trackingStatus = value; }
    }
    #endregion

    #region Methods
    public virtual void UpdateTrackingStatus(string NewStatus)
    {
        if (!string.IsNullOrEmpty(NewStatus))
        {
            TrackingStatus = NewStatus;
            OnTrackingStatusChanged(NewStatus);
        }
    }

    public virtual string GetTrackingStatus()
    {
        return ($"Tracking status for {TrackingCode} changed to: {TrackingStatus}.");
    }

    #region partial maethod
    partial void OnTrackingStatusChanged(string newStatus);

    #endregion

    #endregion

}
