using System;
using Application.use_case.entretien;

namespace Application.model
{
    public class Entretien
    {
        public DateTime DateEntretien { get; set; }

        public string  Status { get; set; }

        public ConsultantRecruteur ConsultantRecruteur { get; set; }
        public Salle Salle { get; set; }
    }
}
