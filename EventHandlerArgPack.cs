using System;

namespace BaseballScoreboard;

internal class EventHandlerArgPack<TEventArgs> where TEventArgs : EventArgs
{
    public object Sender { get; set; }
    public TEventArgs EventArgs { get; set; }

    public EventHandlerArgPack(object sender, TEventArgs eventArgs)
    {
        Sender = sender;
        EventArgs = eventArgs;
    }
}