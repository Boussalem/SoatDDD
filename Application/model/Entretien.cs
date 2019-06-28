using System.Collections.Generic;
using System.Linq;

namespace Application.model
{
    public class Entretien
    {
        public Creneau Creneau { get; set; }
        public EntretienStatus Status { get; set; }
        public Candidat Candidat { get; set; }
        public ConsultantRecruteur ConsultantRecruteur { get; set; }

        public Entretien Schedule(IEnumerable<ConsultantRecruteur> availableRecruteurs)
        {
            ConsultantRecruteur = Match(availableRecruteurs);
            Status = ConsultantRecruteur != null ? EntretienStatus.Scheduled : EntretienStatus.NoScheduleAvailable;

            return this;
        }

        private ConsultantRecruteur Match(IEnumerable<ConsultantRecruteur> consultantRecruteurs)
        {
            return consultantRecruteurs.FirstOrDefault(consultantRecruteur => consultantRecruteur.IsAvailableAt(Creneau)
                                         && consultantRecruteur.CanInterview(Candidat.Profile));
        }
    }

    public enum EntretienStatus
    {
        ToBeScheduled = 0,
        Scheduled = 1,
        Done = 2,
        Canceled = 3,
        NoScheduleAvailable = 4,
    }
}
