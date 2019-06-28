using System;
using Application.Dtos;

namespace Application.model
{
    internal class Creneau
    {
        private Creneau() {}

        public Creneau(CreneauDto dto)
        {
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
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

        public static explicit operator CreneauDto(Creneau creneau)
        {
            return new CreneauDto
            {
                StartDate = creneau.StartDate,
                EndDate = creneau.EndDate,
            };
        }
    }
}