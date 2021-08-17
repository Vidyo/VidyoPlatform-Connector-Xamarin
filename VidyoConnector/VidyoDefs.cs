using System;
using System.Collections.Generic;

namespace VidyoConnector
{
    public enum VidyoConnectorState
    {
        VidyoConnectorStateDisconnected,
        VidyoConnectorStateDisconnectedUnexpected,
        VidyoConnectorStateConnectionFailure,
        VidyoConnectorStateConnected,
    };

    public enum VidyoCallAction
    {
        VidyoCallActionConnect,
        VidyoCallActionDisconnect
    }

    public class VidyoDefs
    {
        static Dictionary<VidyoConnectorState, string> _stateDescription = new Dictionary<VidyoConnectorState, string>()
        {
            { VidyoConnectorState.VidyoConnectorStateConnected, "Connected"},
            { VidyoConnectorState.VidyoConnectorStateDisconnected, "Disconnected"},
            { VidyoConnectorState.VidyoConnectorStateDisconnectedUnexpected, "Unexpected disconnection"},
            { VidyoConnectorState.VidyoConnectorStateConnectionFailure, "Connection failed"}
        };
        static public Dictionary<VidyoConnectorState, string> StateDescription { get { return _stateDescription; } }
    }
}
