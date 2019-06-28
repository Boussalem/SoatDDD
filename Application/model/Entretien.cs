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
        public Salle Salle { get; set; }

        public ConsultantRecruteur Match(IEnumerable<ConsultantRecruteur> salles, Creneau creneau)
        {
            return salles.FirstOrDefault(consultantRecruteur => consultantRecruteur.IsAvailableAt(creneau)
                                         && consultantRecruteur.CanInterview(Candidat.Profile));
        }

        public Salle Match(IEnumerable<Salle> salles, Creneau creneau)
        {
            return salles.FirstOrDefault(salle => salle.IsAvailableAt(creneau));
        }
    }

    public enum EntretienStatus
    {
        ToBeScheduled = 0,
        Scheduled = 1,
        Done = 2,
        Canceled = 3,
    }
}
