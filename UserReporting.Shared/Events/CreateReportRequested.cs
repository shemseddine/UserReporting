using System;

namespace UserReporting.Shared.Events
{
    public class CreateReportRequested : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinedOn { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
    }
}
