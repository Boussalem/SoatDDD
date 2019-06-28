using Application.infrastructure;
using Application.model;
using System;
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

        public EntretienDto PlanifierUnEntretien(DateTimeOffset date, Candidat candidat)
        {
            var availableConsultantRecruteur = _consultantRecruteurRepository.GetAvailableConsultantRecruteurForDate(date);
            var salles = _salleRepository.Get(date);
            var entretien = new Entretien
            {
                Candidat = candidat,
                Creneau = new Creneau(date, TimeSpan.FromHours(1)),
            }.Schedule(availableConsultantRecruteur);
            
            return new EntretienDto
            {
                Salle = new SalleAggregate().Match(salles, entretien.Creneau),
                Entretien = entretien,
            };
        }
    }
}
