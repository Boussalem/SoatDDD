using Application.infrastructure;
using Application.model;
using Application.Dtos;

namespace Application.use_case.entretien
{
    public class PlanifierEntretien
    {
        private readonly IConsultantRecruteurRepository _consultantRecruteurRepository;
        private readonly ISalleRepository _salleRepository;

        public  PlanifierEntretien(IConsultantRecruteurRepository consultantRecruteurRepository, ISalleRepository salleRepository)
        {
            _consultantRecruteurRepository = consultantRecruteurRepository;
            _salleRepository = salleRepository;
        }

        public RendezVousDto PlanifierUnEntretien(CreneauDto creneau, CandidatDto candidat)
        {
            var availableConsultantRecruteur = _consultantRecruteurRepository.GetAvailableConsultantRecruteurForDate(creneau.StartDate);
            var salles = _salleRepository.Get(creneau.StartDate);
            var entretien = new Entretien(creneau, candidat)
                .Schedule(availableConsultantRecruteur);
            
            return new RendezVousDto
            {
                Salle = (SalleDto) new SalleAggregate().Match(salles, creneau).Salle,
                Entretien = (EntretienDto) entretien,
            };
        }
    }
}
