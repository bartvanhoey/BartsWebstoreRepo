using Abp.Events.Bus.Entities;

namespace BartsWebstore.Events
{
    public class EventCancelledEvent : EntityEventData<Event>
    {
        public EventCancelledEvent(Event @event) : base(@event)
        {
        }
    }
}