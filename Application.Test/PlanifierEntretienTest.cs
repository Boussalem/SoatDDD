using Application.model;
using System;
using System.Collections.Generic;
using Xunit;
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
            Mock<IConsultantRecruteurRepository> mockConsultantRecrueteurRepository = new Mock<IConsultantRecruteurRepository>();
            var salleRepository = new Mock<ISalleRepository>();
            List<ConsultantRecruteur> consultantRecruteursAttendus = new List<ConsultantRecruteur>
            {
                new ConsultantRecruteur
                {
                    Name = "Alain",
                    Profile = new Profile(2),
                },
                new ConsultantRecruteur
                {
                    Name = "Remi",
                    Profile = new Profile(7),
                }
            };

            mockConsultantRecrueteurRepository.Setup(x => x.GetAvailableConsultantRecruteurForDate(DateTime.Today)).Returns(consultantRecruteursAttendus);

            var salles = new []
            {
                new Salle
                {
                    Name = "salle",
                }, 
            };
            
            salleRepository.Setup(r => r.Get(It.IsAny<DateTimeOffset>()))
                .Returns(salles);
            Candidat candidat = new Candidat
            {
                Name = "Max",
                Profile = new Profile(2),
            };

            //ACT 
            var planifierEntretien = new PlanifierEntretien(mockConsultantRecrueteurRepository.Object, salleRepository.Object);
            var entretien = planifierEntretien.PlanifierUnEntretien(DateTime.Today, candidat);

            
            //ASSERT
            //Assert.True(!firstNotSecond.Any() && !secondNotfirst.Any());
            Assert.IsType<Entretien>(entretien);
            Assert.Equal(DateTime.Today, entretien.Creneau.StartDate);
            Assert.Equal(EntretienStatus.Scheduled, entretien.Status);
            Assert.Equal("Remi", entretien.ConsultantRecruteur.Name);
            Assert.Equal(7, entretien.ConsultantRecruteur.Profile.Experience);
            Assert.Equal("salle", entretien.Salle.Name);
        }
    }
}
