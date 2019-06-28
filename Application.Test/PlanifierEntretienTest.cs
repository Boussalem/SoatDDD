using Application.model;
using System;
using Application.Dtos;
using Xunit;
using Application.infrastructure;
using Moq;
using Application.use_case.entretien;
using FluentAssertions;

namespace Application.Test
{
    public class PlanifierEntretienTest
    {
        [Fact]
        public void ShouldGiveMeAllAvailableConsultantRecruteurForDate()
        {
            var now = DateTimeOffset.UtcNow;

            //ARRANGE 
            var consultantRecruteurRepository = new Mock<IConsultantRecruteurRepository>();
            var salleRepository = new Mock<ISalleRepository>();
            var consultantRecruteurs = new []
            {
                new ConsultantRecruteurDto
                {
                    Name = "Alain",
                    Profile = new ProfileDto { Experience = 2 },
                },
                new ConsultantRecruteurDto
                {
                    Name = "Remi",
                    Profile = new ProfileDto { Experience = 7 },
                }
            };

            consultantRecruteurRepository.Setup(x => x.GetAvailableConsultantRecruteurForDate(It.IsAny<DateTimeOffset>()))
                .Returns(consultantRecruteurs);

            var salles = new []
            {
                new SalleDto
                {
                    Name = "salle",
                }, 
            };
            
            salleRepository.Setup(r => r.Get(It.IsAny<DateTimeOffset>()))
                .Returns(salles);
            var candidat = new CandidatDto
            {
                Name = "Max",
                Profile = new ProfileDto { Experience = 2 },
            };
            var creneau = new CreneauDto
            {
                StartDate = now,
                EndDate = now.AddHours(1),
            };

            //ACT 
            var planifierEntretien = new PlanifierEntretien(consultantRecruteurRepository.Object, salleRepository.Object);
            var result = planifierEntretien.PlanifierUnEntretien(creneau, candidat);

            var expected = new RendezVousDto
            {
                Salle = salles[0],
                Entretien = new EntretienDto
                {
                    Creneau = creneau,
                    Candidat = candidat,
                    ConsultantRecruteur = consultantRecruteurs[1],
                    Status = EntretienStatus.Scheduled,
                },
            };

            //ASSERT
            result.Should().BeEquivalentTo(expected);
        }
    }
}
