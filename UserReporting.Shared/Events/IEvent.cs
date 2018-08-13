using System;

namespace UserReporting.Shared.Events
{
    public interface IEvent
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; }
    }
}
