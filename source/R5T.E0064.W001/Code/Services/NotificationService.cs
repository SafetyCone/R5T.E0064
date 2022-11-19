using System;
using System.Collections.Generic;

using R5T.T0064;


namespace R5T.E0064.W001
{
    [DraftServiceImplementationMarker]
    public class NotificationService : IDraftServiceImplementation
    {
        public Dictionary<string, EventNofifier> ChannelsByName { get; } = new Dictionary<string, EventNofifier>();
    }


    public class EventNofifier
    {
        public event EventHandler NotificationHandler;


        public void Notify()
        {
            this.NotificationHandler?.Invoke(
                this,
                new EventArgs());
        }
    }
}
