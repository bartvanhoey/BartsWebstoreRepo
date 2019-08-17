using Abp.Events.Bus.Entities;

namespace BartsWebstore.Events
{
    public class EvendDateChangedEvent : EntityEventData<Event>
    {
        public EvendDateChangedEvent(Event entity) : base(entity)
        {
        }
    }
}