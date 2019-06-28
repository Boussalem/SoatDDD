using System;

namespace Application.model
{
    public class Creneau
    {
        private Creneau() {}

        public Creneau(DateTimeOffset startDate, TimeSpan duration)
        {
            StartDate = startDate;
            EndDate = startDate + duration;
        }

        public DateTimeOffset StartDate { get; }
        public DateTimeOffset EndDate { get; }
    }
}