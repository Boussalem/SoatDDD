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
            var now = DateTimeOffset.UtcNow;

            //ARRANGE 
            Mock<IConsultantRecruteurRepository> consultantRecruteurRepository = new Mock<IConsultantRecruteurRepository>();
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

            consultantRecruteurRepository.Setup(x => x.GetAvailableConsultantRecruteurForDate(It.IsAny<DateTimeOffset>()))
                .Returns(consultantRecruteursAttendus);

            var salles = new []
            {
                new Salle
                {
                    Name = "salle",
                }, 
            };
            
            salleRepository.Setup(r => r.Get(It.IsAny<DateTimeOffset>()))
                .Returns(salles);
            var candidat = new Candidat
            {
                Name = "Max",
                Profile = new Profile(2),
            };

            //ACT 
            var planifierEntretien = new PlanifierEntretien(consultantRecruteurRepository.Object, salleRepository.Object);
            var entretienDto = planifierEntretien.PlanifierUnEntretien(DateTimeOffset.Now, candidat);
            var creneau = new Creneau(now, TimeSpan.FromHours(1));
         
            
            //ASSERT

            Assert.Equal(creneau, entretienDto.Entretien.Creneau);
            Assert.Equal(EntretienStatus.Scheduled, entretienDto.Entretien.Status);
            Assert.Equal("Remi", entretienDto.Entretien.ConsultantRecruteur.Name);
            Assert.Equal(7, entretienDto.Entretien.ConsultantRecruteur.Profile.Experience);
            Assert.Equal("salle", entretienDto.Salle.Salle.Name);
        }
    }
}
