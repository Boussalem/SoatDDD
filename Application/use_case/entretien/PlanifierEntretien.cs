using Application.infrastructure;
using Application.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.use_case.entretien
{
    public class PlanifierEntretien
    {
        public IConsultantRecrueteurRepository consultantRecrueteurRepository;
        

        public  PlanifierEntretien(IConsultantRecrueteurRepository consultantRecrueteurRepository)
        {
            this.consultantRecrueteurRepository = consultantRecrueteurRepository;
        }

        public Entretien PlanifierUnEntretien(DateTime date , Candidat candidat)
        {
            ConsultantRecruteur consultantRecruteurdispo = consultantRecrueteurRepository.GetAvailableConsultantRecruteurForDate(DateTime.Today).
                OrderByDescending(x => x.AnneExperience).FirstOrDefault(x => x.AnneExperience > candidat.AnneExperience);
            return new Entretien
            {
                DateEntretien = DateTime.Today,
                Status = consultantRecruteurdispo == null? "Invalid" : "Valid",
                ConsultantRecruteur = consultantRecruteurdispo
            };
        }
        
    }
}
