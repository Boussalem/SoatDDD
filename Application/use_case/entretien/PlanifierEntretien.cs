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

        public Entretien PlanifierUnEntretien(DateTime date, Candidat candidat)
        {
            ConsultantRecruteur consultantRecruteurdispo = _consultantRecruteurRepository.GetAvailableConsultantRecruteurForDate(DateTime.Today).
                OrderByDescending(x => x.AnneExperience).FirstOrDefault(x => x.AnneExperience > candidat.AnneExperience);
            var salle = _salleRepository.Get(date).FirstOrDefault();
            return new Entretien
            {
                DateEntretien = DateTime.Today,
                Status = consultantRecruteurdispo == null && salle != null ? "Invalid" : "Valid",
                ConsultantRecruteur = consultantRecruteurdispo,
                Salle = salle,
            };
        }
    }
}
