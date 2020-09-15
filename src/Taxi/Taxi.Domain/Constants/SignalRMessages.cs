namespace Taxi.Domain.Constants
{
    public class SignalRMessages
    {
        public const string GetDriverLocation = "GetDriverLocation";
        public const string UpdateDriverLocation = "UpdateDriverLocation";
        public const string RemoveDriverLocation = "RemoveDriverLocation";

        public const string OrderRequested = "OrderRequested";
        public const string OrderRefused = "OrderRefused";
        public const string OrderAccepted = "OrderAccepted";
        public const string OrderFinalized = "OrderFinalized";
    }
}