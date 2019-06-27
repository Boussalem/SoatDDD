using Application.model;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using Application.infrastructure;
using Moq;
using Application.use_case.entretien;

namespace Application.Test
{
    public class PlanifierEntretienTest
    {
        [Fact]
        public void ShouldGiveMeAllAvailableConsultantRecrueteurForDate()
        {
            //ARRANGE 
            Mock<IConsultantRecrueteurRepository> mockConsultantRecrueteurRepository = new Mock<IConsultantRecrueteurRepository>();
            List<ConsultantRecruteur> consultantRecruteursAttendus = new List<ConsultantRecruteur>
            {
                new ConsultantRecruteur
                {
                    Name = "Alain",
                    AnneExperience = 2
                },
                new ConsultantRecruteur
                {
                    Name = "Remi",
                    AnneExperience = 7
                }
            };

            mockConsultantRecrueteurRepository.Setup(x => x.GetAvailableConsultantRecruteurForDate(DateTime.Today)).Returns(consultantRecruteursAttendus);
            Candidat candidat = new Candidat
            {
                Name = "Max",
                AnneExperience = 2
            };



            //ACT 
            PlanifierEntretien planifierEntretien = new PlanifierEntretien(mockConsultantRecrueteurRepository.Object);
            Entretien entretien = planifierEntretien.PlanifierUnEntretien(DateTime.Today, candidat);

            
            //ASSERT
            //Assert.True(!firstNotSecond.Any() && !secondNotfirst.Any());
            Assert.IsType<Entretien>(entretien);
            Assert.Equal(entretien.DateEntretien, DateTime.Today);
            Assert.Equal(entretien.Status, "Valid");
            Assert.Equal(entretien.ConsultantRecruteur.Name, "Remi");
            Assert.Equal(entretien.ConsultantRecruteur.AnneExperience, 7);
        }
    }
}
