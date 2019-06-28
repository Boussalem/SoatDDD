using System.Collections.Generic;
using System.Linq;
using Application.Dtos;

namespace Application.model
{
    public class Entretien
    {
        internal Creneau Creneau { get; set; }
        internal EntretienStatus Status { get; set; }
        internal Candidat Candidat { get; set; }
        internal ConsultantRecruteur ConsultantRecruteur { get; set; }

        public Entretien(CreneauDto creneau, CandidatDto candidat)
        {
            Candidat = new Candidat(candidat);
            Creneau = new Creneau(creneau);
        }

        public Entretien Schedule(IEnumerable<ConsultantRecruteurDto> availableRecruteurs)
        {
            ConsultantRecruteur = Match(availableRecruteurs.Select(r => new ConsultantRecruteur(r)));
            Status = ConsultantRecruteur != null ? EntretienStatus.Scheduled : EntretienStatus.NoScheduleAvailable;

            return this;
        }

        private ConsultantRecruteur Match(IEnumerable<ConsultantRecruteur> consultantRecruteurs)
        {
            var availableRecruteurs = consultantRecruteurs.Where(consultantRecruteur => consultantRecruteur.IsAvailableAt(Creneau));
            Profile profile = new Profile(Candidat.Profile.Experience);
            var Recruteur = profile.RecruteurMatchingProfile(availableRecruteurs);
            return Recruteur;       
        }

        public static explicit operator EntretienDto(Entretien entretien)
        {
            return new EntretienDto
            {
                Creneau = (CreneauDto) entretien.Creneau,
                Candidat = (CandidatDto) entretien.Candidat,
                ConsultantRecruteur = (ConsultantRecruteurDto) entretien.ConsultantRecruteur,
                Status = (EntretienStatusDto) entretien.Status,
            };
        }
    }

    // TODO dto
    public enum EntretienStatus
    {
        ToBeScheduled = 0,
        Scheduled = 1,
        Done = 2,
        Canceled = 3,
        NoScheduleAvailable = 4,
    }
}
