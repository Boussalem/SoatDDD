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

        public override bool Equals(object obj)
        {
            var creneau = obj as Creneau;
            return creneau != null &&
                   StartDate.Equals(creneau.StartDate) &&
                   EndDate.Equals(creneau.EndDate);
        }
    }
}