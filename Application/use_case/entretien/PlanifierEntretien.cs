using Application.infrastructure;
using Application.model;
using System;
using System.Linq;

namespace Application.use_case.entretien
{
    public class PlanifierEntretien
    {
        private readonly IConsultantRecrueteurRepository _consultantRecruteurRepository;
        private readonly ISalleRepository _salleRepository;

        public  PlanifierEntretien(IConsultantRecrueteurRepository consultantRecruteurRepository, ISalleRepository salleRepository)
        {
            _consultantRecruteurRepository = consultantRecruteurRepository;
            _salleRepository = salleRepository;
        }

        public Entretien PlanifierUnEntretien(DateTimeOffset date, Candidat candidat)
        {
            var consultantRecruteurdispo = _consultantRecruteurRepository.GetAvailableConsultantRecruteurForDate(DateTime.Today)
                .OrderByDescending(cr => cr.Profile.Experience)
                .FirstOrDefault(cr => cr.CanInterview(candidat.Profile));
            var salle = _salleRepository.Get(date).FirstOrDefault();

            //todo error handling
            return new Entretien
            {
                Creneau = new Creneau(date, TimeSpan.FromHours(1)),
                Status = EntretienStatus.Scheduled,
                ConsultantRecruteur = consultantRecruteurdispo,
                Salle = salle,
            };
        }
    }
}
