using NextShip.Api.Interfaces;

namespace NextShip.NextEvents;

public class HudManagerUpdateEvent(HudManager Instance) : INextEvent
{
    public HudManager _HudManager = Instance;
    public string EventName { get; set; }

    public int Id { get; set; }


    public void OnRegister(IEventManager eventManager)
    {
    }

    public void OnUnRegister(IEventManager eventManager)
    {
    }

    public void Call(INextEvent @event)
    {
    }
}