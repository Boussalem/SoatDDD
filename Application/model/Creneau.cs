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
            return creneau != null  &&
                   StartDate.TimeOfDay.Minutes.Equals(creneau.StartDate.TimeOfDay.Minutes) &&
                   EndDate.TimeOfDay.Minutes.Equals(creneau.EndDate.TimeOfDay.Minutes)
                   && StartDate.Day.Equals(creneau.StartDate.Day) &&
                   EndDate.Day.Equals(creneau.EndDate.Day);
        }
    }
}